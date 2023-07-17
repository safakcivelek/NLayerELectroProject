using NLayer.Core.Entities.Concert;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository: IGenericRepositoryBase<Product>
    {      
        IList<Product> GetBestSellers(int? count);
    }
}
