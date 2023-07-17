using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;
using NLayer.Web.Models;

namespace NLayer.Web.ViewComponents
{
    public class LeftSideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public LeftSideBarViewComponent(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var productsByPrice = await _productService.GetAllByPriceCountAsync(isAscending: false, takeSize: 4);
            var products = await _productService.GetAllByNonDeletedAndActiveAsync();

            return View(new LeftSideBarViewModel
            {
                Categories = categoriesResult.Data.Categories,
                ProductsByPrice = productsByPrice.Data.Products,
                Products = products.Data.Products
            });
        }
    }
}
