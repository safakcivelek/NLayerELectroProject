using LinqKit;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Repositories;
using NLayer.Repository.EntityFramework.Contexts;
using System.Linq.Expressions;

namespace NLayer.Repository.EntityFramework.Repositories
{
    public class GenericRepositoryBase<T> : IGenericRepositoryBase<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _context;
        public GenericRepositoryBase(ElectroDbContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }    
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().SingleOrDefaultAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
              _context.Set<T>().Update(entity);
                
            });
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
            });
        }
        public async Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicates.Any())
            {
                // PredicateBuilder LinqKit paketinden geliyor.
                var predicateChain = PredicateBuilder.New<T>();
                foreach (var predicate in predicates)
                {
                    /*
                    // Normalde query.Where metodunun davranışı şu şekildedir; predicate1 && predicate2 && predicateNtane diye gider.(&& => ve)
                    // Fakat ben predicate'lerin veya operatörü ile eklnmesini istiyorum. Demek istediğim şey şu aslında;
                    // Buradaki predicate'yi =>  ürün adında veya kategori adında veya ürünün açıklamasında bulursan bana getir demek istiyorum.
                    // Oysaki Where'li senaryomda hepsinin yani tüm parametrelerin doğru olmasını bekliyordu.
                    // Burada 'or' operatörünü kullanabilmek için 'LinqKit' isimli paketi yükleyeceğim. LinqKit ekstra metodlar sağlar.
                    */
                    // query = query.Where(predicate);  Bu alanı pasife çekiyorum!

                    //predicate1 || predicate2 ||  predicateNtane diye devam eder...
                    predicateChain.Or(predicate);
                }
                query = query.Where(predicateChain);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            /* AsNoTracking =>
             * Eksta sorgular yapılmasını engeller ayrıca birbirine referans eden verilerin tekrar eden sorgular oluşturmasının önüne geçer.
             * Bu sayede büyük bir performans kazanmış olurum.
             * Bu ayarı verdiğimde eklemediğim include'ların gereksiz bir şekilde gelmesini engellerim.
             */
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await (predicate == null ? _context.Set<T>().CountAsync() : _context.Set<T>().CountAsync(predicate));
        }
        public IQueryable<T> GetAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}