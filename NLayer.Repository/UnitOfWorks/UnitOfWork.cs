using NLayer.Core.Repositories;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.EntityFramework.Contexts;
using NLayer.Repository.EntityFramework.Repositories;

namespace NLayer.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ElectroDbContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private OrderRepository _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private CommentRepository _commentRepository;
        public UnitOfWork(ElectroDbContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);
        public ICommentRepository Comments => _commentRepository ??= new CommentRepository(_context);
        public IOrderDetailRepository OrderDetails => _orderDetailRepository ??= new OrderDetailRepository(_context);
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        //Dispose=> Garbage Collector yapısı bellekte yeterli yer olduğu zaman nesneleri bellekten temizleme işini erteleyebiliyor.
        //Bu yüzden kullanılan nesne ile ilgili işlemimiz bittiğinde, nesnenin bellekten temizlendiğinden emin olmak için "DisposeAsync" metodunu kullandım.
    }
}
