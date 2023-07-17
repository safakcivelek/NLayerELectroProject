using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Results.Abstract;

namespace NLayer.Core.Services
{
    public interface IOrderService
    {
        Task<IDataResult<OrderDto>> GetOrderDetailsListAsync(int orderId);
        Task<IDataResult<OrderDto>> ApproveAsync(int orderId, string modifiedByName, string loggedInUser);
        Task<IDataResult<OrderUpdateDto>> GetOrderUpdatedDtoAsync(int orderId);
        Task<IDataResult<OrderListDto>> GetAllAsync();    
        Task<IDataResult<OrderListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<OrderListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<OrderListDto>> GetOrdersOfCustomerAsync(int loggedInUserId); 
        Task<IDataResult<OrderListDto>> GetAllByDeletedAsync();
        Task<IDataResult<OrderDto>> GetAsync(int orderId);       
        Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto,string modifiedByName);
        Task<IDataResult<OrderDto>> DeleteAsync(int orderId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int categoryId);
        Task<IDataResult<OrderDto>> UndoDeleteAsync(int orderId, string modifiedByName);
        Task<IDataResult<int>> Count();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
