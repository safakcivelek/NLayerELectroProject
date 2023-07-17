using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Core.Utilities.Results.Concert;
using NLayer.Service.Utilities;
using Order = NLayer.Core.Entities.Concert.Order;

namespace NLayer.Service.Services
{
    public class OrderManager : ManagerBase, IOrderService
    {
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<OrderDto>> ApproveAsync(int orderId, string modifiedByName, string loggedInUser)
        {
            var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId, o => o.User);
            if (order != null)
            {
                if (!order.IsActive)
                {
                    order.IsActive = true;
                    order.Status = OrderStatus.ConfirmedOrder;
                    order.ModifiedByName = modifiedByName;
                    order.ModifiedDate = DateTime.Now;
                    order.CreatedByName = loggedInUser;
                }
                else
                {
                    order.IsActive = false;
                    order.Status = OrderStatus.ReceivedOrder;
                    order.ModifiedByName = modifiedByName;
                    order.ModifiedDate = DateTime.Now;
                }
                var updatedOrder = await UnitOfWork.Orders.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
                return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Approve(orderId), new OrderDto
                {
                    Order = updatedOrder
                });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderListDto>> GetAllAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(null, o => o.User);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto { Orders = orders });
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<OrderListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => !o.IsDeleted && o.IsActive, o => o.User);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
                {
                    Orders = orders,
                });
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), new OrderListDto
            {
                Orders = null
            });
        }
        public async Task<IDataResult<OrderListDto>> GetAllByNonDeletedAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => !o.IsDeleted, o => o.User, od => od.OrderDetails);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
                {
                    Orders = orders,
                });
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), new OrderListDto
            {
                Orders = null
            });
        }
        public async Task<IDataResult<OrderListDto>> GetOrdersOfCustomerAsync(int loggedInUserId)
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => !o.IsDeleted && o.UserId == loggedInUserId, o => o.User, od => od.OrderDetails);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
                {
                    Orders = orders,
                });
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), new OrderListDto
            {
                Orders = null
            });
        }
        public async Task<IDataResult<OrderListDto>> GetAllByDeletedAsync()
        {
            var orders = await UnitOfWork.Orders.GetAllAsync(o => o.IsDeleted, o => o.User);
            if (orders.Count > -1)
            {
                return new DataResult<OrderListDto>(ResultStatus.Success, new OrderListDto
                {
                    Orders = orders,
                });
            }
            return new DataResult<OrderListDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: true), new OrderListDto
            {
                Orders = null
            });
        }
        public async Task<IDataResult<OrderDto>> GetOrderDetailsListAsync(int orderId)
        {
            var order = await UnitOfWork.Orders.OrderGetAsync(i => i.Id == orderId, i => i.User);
            if (order != null)
            {
                return new DataResult<OrderDto>(ResultStatus.Success, new OrderDto { Order = order });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderDto>> GetAsync(int orderId)
        {
            var order = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId, o => o.OrderDetails);
            if (order != null)
            {
                return new DataResult<OrderDto>(ResultStatus.Success, new OrderDto { Order = order });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderUpdateDto>> GetOrderUpdatedDtoAsync(int orderId)
        {
            var result = await UnitOfWork.Orders.AnyAsync(o => o.Id == orderId);
            if (result)
            {
                var orders = await UnitOfWork.Orders.GetAsync(o => o.Id == orderId, o => o.User);
                var orderUpdateDto = Mapper.Map<OrderUpdateDto>(orders);
                return new DataResult<OrderUpdateDto>(ResultStatus.Success, orderUpdateDto);
            }
            return new DataResult<OrderUpdateDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderDto>> UpdateAsync(OrderUpdateDto orderUpdateDto, string modifiedByName)
        {
            var oldOrder = await UnitOfWork.Orders.GetAsync(o => o.Id == orderUpdateDto.Id);
            if (oldOrder != null)
            {
                var order = Mapper.Map<OrderUpdateDto, Order>(orderUpdateDto, oldOrder);
                order.ModifiedByName = modifiedByName;
                order.Status = order.IsActive != true ? OrderStatus.ReceivedOrder : OrderStatus.ConfirmedOrder;
                var updatedOrder = await UnitOfWork.Orders.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
                return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Update(updatedOrder.Id), new OrderDto { Order = updatedOrder });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<OrderDto>> DeleteAsync(int orderId, string modifiedByName)
        {
            var order = await UnitOfWork.Orders.GetAsync(c => c.Id == orderId);
            if (order != null)
            {
                order.IsDeleted = true;
                order.IsActive = false;
                order.ModifiedByName = modifiedByName;
                order.ModifiedDate = DateTime.Now;
                var deletedOrder = await UnitOfWork.Orders.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
                return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.Delete(orderId), new OrderDto
                {
                    Order = deletedOrder
                });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IResult> HardDeleteAsync(int orderId)
        {
            var order = await UnitOfWork.Orders.GetAsync(c => c.Id == orderId);
            if (order != null)
            {
                await UnitOfWork.Orders.DeleteAsync(order);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Order.HardDelete(orderId));
            }
            return new Result(ResultStatus.Error, Messages.Order.NotFound(isPlural: false));
        }
        public async Task<IDataResult<OrderDto>> UndoDeleteAsync(int orderId, string modifiedByName)
        {
            var order = await UnitOfWork.Orders.GetAsync(c => c.Id == orderId);
            if (order != null)
            {
                order.IsDeleted = false;
                //order.IsActive = true;
                order.ModifiedByName = modifiedByName;
                order.ModifiedDate = DateTime.Now;
                var deletedOrder = await UnitOfWork.Orders.UpdateAsync(order);
                await UnitOfWork.CommitAsync();
                return new DataResult<OrderDto>(ResultStatus.Success, Messages.Order.UndoDelete(orderId), new OrderDto
                {
                    Order = deletedOrder
                });
            }
            return new DataResult<OrderDto>(ResultStatus.Error, Messages.Order.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<int>> Count()
        {
            var productsCount = await UnitOfWork.Orders.CountAsync();
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, $"Sipariş sayısı => {productsCount}", productsCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmedik bir hata oluştu!", -1);
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var productsCount = await UnitOfWork.Orders.CountAsync(o => o.IsDeleted == false);
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, $"Sipariş sayısı => {productsCount}", productsCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Beklenmedik bir hata oluştu!", -1);
        }
    }
}
