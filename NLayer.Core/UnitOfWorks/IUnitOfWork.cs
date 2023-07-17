using NLayer.Core.Repositories;

namespace NLayer.Core.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }     
        IOrderDetailRepository OrderDetails { get; }
        ICommentRepository Comments { get; }     
        
        Task<int> CommitAsync();
    }
}
