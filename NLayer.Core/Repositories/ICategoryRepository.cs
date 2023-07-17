using NLayer.Core.Entities.Concert;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepositoryBase<Category>
    {
        Task<Category> GetByCategoryId(int categoryId);
    }
}
