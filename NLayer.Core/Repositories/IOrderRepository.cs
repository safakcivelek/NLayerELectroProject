using NLayer.Core.Entities.Concert;
using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IOrderRepository : IGenericRepositoryBase<Order>
    {      
       Task<Order> OrderGetAsync(Expression<Func<Order, bool>> predicate,params Expression<Func<Order, object>>[] includeProperties);
    }
}
