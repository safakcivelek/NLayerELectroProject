using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Helpers.Abstract;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, IOrderService orderService) : base(userManager, mapper, imageHelper)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _orderService.GetAllByNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }
        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Update(int orderId)
        {
            var result = await _orderService.GetOrderUpdatedDtoAsync(orderId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return NotFound();            
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateDto orderUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _orderService.UpdateAsync(orderUpdateDto, LoggedInUser.UserName);
                
                if (result.ResultStatus == ResultStatus.Success)
                {
                    orderUpdateDto.Status = result.Data.Order.Status;
                    ViewData["MessageSuccess"] = $"{result.Message}";
                    return View(orderUpdateDto);
                }
                else
                {
                    ViewData["MessageError"] = $"{result.Message}";
                    return View(orderUpdateDto);
                }
            }
            return View(orderUpdateDto);           
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> GetDetail(int orderId)
        {
            var result = await _orderService.GetAsync(orderId);
            if (result.ResultStatus== ResultStatus.Success)
            {
                return PartialView("_DetailPartial",result.Data);
            }
            return NotFound();
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Delete(int orderId)
        {
            var result = await _orderService.DeleteAsync(orderId, LoggedInUser.UserName);
            var orderResult = JsonSerializer.Serialize(result);        
            return Json(orderResult);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int orderId)
        {
            var result = await _orderService.HardDeleteAsync(orderId);
            var hardDeletedOrderResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedOrderResult);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int orderId)
        {
            var result = await _orderService.UndoDeleteAsync(orderId, LoggedInUser.UserName);
            var undoDeletedOrderResult = JsonSerializer.Serialize(result);
            return Json(undoDeletedOrderResult);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> DeletedOrders()
        {
            var orders = await _orderService.GetAllByDeletedAsync();
            return View(orders.Data);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpPost]
        public async Task<IActionResult> Approve(int orderId)
        {
            var loggedInUser = LoggedInUser.UserName;
            var result = await _orderService.ApproveAsync(orderId, loggedInUser, loggedInUser);
            var orderResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(orderResult);
        }
    }
}
