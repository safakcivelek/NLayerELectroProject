using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Models.Order;

namespace NLayer.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
             var loggedInUserId = _userManager.GetUserAsync(HttpContext.User).Result.Id;                 
            var result = await _orderService.GetOrdersOfCustomerAsync(loggedInUserId);
            if (result.ResultStatus == ResultStatus.Success)
            {
               
                return View(result.Data);
            }
            return NotFound();          
        }

        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")]
        [HttpGet]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var result = await _orderService.GetOrderDetailsListAsync(id);
            if (result !=null)
            {
                var order = new OrderDetailsListViewModel
                {
                    OrderId = result.Data.Order.Id,
                    UserId=result.Data.Order.UserId,
                    UserName=result.Data.Order.UserName,
                    OrderNumber = result.Data.Order.OrderNumber,
                    Status = result.Data.Order.Status,
                    Description=result.Data.Order.Description,
                    Total = result.Data.Order.Total,
                    AddressTitle=result.Data.Order.AddressTitle,
                    Address = result.Data.Order.Address,
                    Country = result.Data.Order.Country,
                    City = result.Data.Order.City,
                    District = result.Data.Order.District,
                    PostalCode = result.Data.Order.PostalCode,
                    CreatedDate = result.Data.Order.CreatedDate,
                    CreatedByName=result.Data.Order.CreatedByName, // siparişi veren isim ile aynımı kontrol et                   
                    OrderDetailsViewModels = result.Data.Order.OrderDetails.Select(a=> new OrderDetailsViewModel                   
                    {
                         ProductId=a.ProductId,
                         ProductName=a.Product.Name,
                         Price=a.Product.Price,
                         Quantity=a.Quantity,
                         SubTotal=a.SubTotal,
                         ImageUrl=a.Product.ImageUrl,
                         Color=a.Product.Color,
                         Size=a.Product.Size
                    }).ToList()
                };
                return View(order);
            }
            return NotFound();           
        }
    }
}
