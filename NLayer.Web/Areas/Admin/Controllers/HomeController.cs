using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Areas.Admin.Models;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICategoryService categoryService, IProductService productService, UserManager<User> userManager, ICommentService commentService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _userManager = userManager;
            _commentService = commentService;
            _orderService = orderService;
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        public async Task<IActionResult> Index(int? count)
        {
            var catagoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var productsCountResult = await _productService.CountByNonDeletedAsync();
            var commentsCountResult = await _commentService.CountByNonDeletedAsync();           
            var ordersCountResult = await _orderService.CountByNonDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var lastProductsResult = await _productService.GetLastProductsAsync(5);

            if (catagoriesCountResult.ResultStatus == ResultStatus.Success &&
                productsCountResult.ResultStatus == ResultStatus.Success &&
                commentsCountResult.ResultStatus == ResultStatus.Success &&
                ordersCountResult.ResultStatus == ResultStatus.Success &&
                usersCount > -1 &&
                lastProductsResult.ResultStatus == ResultStatus.Success)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = catagoriesCountResult.Data,
                    ProductsCount = productsCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    OrdersCount = ordersCountResult.Data,
                    UsersCount = usersCount,
                    Products= lastProductsResult.Data
                });
            }
            return NotFound();
        }
    }
}
