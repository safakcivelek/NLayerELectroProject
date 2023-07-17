using NLayer.Core.Entities.Concert;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class OrderDetailRepository : GenericRepositoryBase<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(ElectroDbContext context) : base(context)
        {
        }
    }
}
