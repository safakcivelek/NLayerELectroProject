using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Models;

namespace NLayer.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;

        public CommentController(ICommentService commentService, IProductService productService)
        {
            _commentService = commentService;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto commentAddDto, int productId)
        {
            if (!ModelState.IsValid)
            {
                commentAddDto.ProductId = productId;
                var result = await _commentService.AddAsync(commentAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productsResult = await _productService.GetAsync(productId);
                    var productDetailViewModel = new ProductDetailViewModel
                    {
                        CommentDto = result.Data,
                        CommentAddDto = commentAddDto,
                        ProductDto = productsResult.Data
                    };
                    return RedirectToAction("Detail","Product",new {productId});
                }
                ModelState.AddModelError("", result.Message);
            }
            var ErrorModel = new ProductDetailViewModel
            {
                CommentAddDto = commentAddDto
            };
            return PartialView("_CommentAddPartial", ErrorModel);
        }
    }
}
