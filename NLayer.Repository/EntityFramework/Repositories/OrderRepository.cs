using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;
using System.Linq.Expressions;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class OrderRepository : GenericRepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ElectroDbContext context) : base(context)
        {
        }

        public async Task<Order> OrderGetAsync(Expression<Func<Order, bool>> predicate, params Expression<Func<Order, object>>[] includeProperties)
        {
           IQueryable<Order> query = _context.Set<Order>()
                                             .Where(predicate)
                                             .Include(i => i.OrderDetails)
                                             .ThenInclude(i => i.Product);
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }        
    }
}
