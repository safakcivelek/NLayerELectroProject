using NLayer.Core.Entities.Concert;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class ProductRepository : GenericRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ElectroDbContext context) : base(context)
        {
        }
        public ElectroDbContext ElectroContext
        {
            get
            {
                return _context as ElectroDbContext;
            }
        }
        public IList<Product> GetBestSellers(int? count)
        {
            var query = from p in ElectroContext.Products
                        join od in ElectroContext.OrderDetails on p.Id equals od.ProductId
                        join c in ElectroContext.Categories on p.CategoryId equals c.Id
                        group od by new { p.Id, p.Name, p.IsActive, p.IsDeleted, p.ImageUrl, p.Price, CategoryName = c.Name } into g
                        select new
                        {                            
                            g.Key.CategoryName,
                            g.Key.Id,
                            g.Key.Name,
                            g.Key.IsActive,
                            g.Key.IsDeleted,
                            g.Key.ImageUrl,
                            g.Key.Price,
                            Sum = g.Sum(p => p.Quantity)
                        };
            query = query.OrderByDescending(p => p.Sum).Where(p => p.IsActive == true && p.IsDeleted == false).Take(count.Value);

            IList<Product> products = new List<Product>();
            foreach (var item in query)
            {
                products.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                    Category = new Category() { Name = item.CategoryName },                  
                });
            }
            return products;
        }
    }
}
