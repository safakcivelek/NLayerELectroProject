using NLayer.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);        
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);       
        Task<T> GetById(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchAsync(IList<Expression<Func<T,bool>>> predicates, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        // Örneğin UniOfWork.Products.GetAsQueryble dediğimde bana Products objesini artık bir Queryable objesi olarak return edicek.   
        // Komplek sorgularda yardımı olur(örneğin; çoka çok ilişkili include işlemlerinde...)
        IQueryable<T> GetAsQueryable();
    }
}
