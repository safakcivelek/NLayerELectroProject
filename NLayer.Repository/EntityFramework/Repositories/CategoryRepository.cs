using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class CategoryRepository : GenericRepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ElectroDbContext context) : base(context)
        {
        }
        // Kullanmak istediğim context'i burada field olarak ekliyorum.
        private ElectroDbContext ElectroDbContext 
        {
            get
            {
                // Yani ben "_context'i" artık bir "ElectroDbContext" olarak kullanmak istiyorum demiş oldum.
                return _context as ElectroDbContext;
            }
        }  
        public async Task<Category> GetByCategoryId(int categoryId)
        {
            return await ElectroDbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
