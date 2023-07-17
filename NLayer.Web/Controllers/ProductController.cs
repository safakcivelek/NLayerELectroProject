using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Models;

namespace NLayer.Web.Controllers
{ 
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
       
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = true)
        {
            var searchResult = await _productService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            if (searchResult.ResultStatus == ResultStatus.Success)
            {
                return View(new ProductSearchViewModel
                {
                    ProductListDto = searchResult.Data,
                    Keyword = keyword,
                });
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int productId)
        {           
            var productsResult = await _productService.GetAsync(productId);
            if (productsResult.ResultStatus == ResultStatus.Success)
            {
                var productDetailViewModel = new ProductDetailViewModel
                {
                    ProductDto = productsResult.Data,
                };
                return View(productDetailViewModel);
            }
            return NotFound();
        }
    }
}
