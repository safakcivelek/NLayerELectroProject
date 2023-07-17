using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Areas.Admin.Models;
using NLayer.Web.Helpers.Abstract;
using System.Text.Json;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        /*
         * Imapper ImageHelper ve UserManager gibi servisleri yukarıdaki kısımdan çıkarttım çünkü artık BasControllerden alacağım. Fakat bunları Ctor'un parametsinde veriyorum ve bunları base sınıfıma geçmem gerekiyor, Şöyle ki=> :base(mapper,imageHelper,userManager)
         */
        public ProductController(IProductService productService, ICategoryService categoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllByNonDeletedAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return NotFound();
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> GetDetail(int productId)
        {
            var result = await _productService.GetAsync(productId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_DetailPartial",result.Data);
            }
            return NotFound();
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(new ProductAddViewModel
                {
                    Categories = result.Data.Categories
                });
            }
            return NotFound();
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel productAddViewModel)
        {
            var categorySelectList = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            productAddViewModel.Categories = categorySelectList.Data.Categories;
            if (ModelState.IsValid)
            {
                var productAddDto = Mapper.Map<ProductAddDto>(productAddViewModel);
                var imageResult = await ImageHelper.Upload(productAddViewModel.Name, productAddViewModel.ImageUrlFile, PictureType.Product);
                productAddDto.ImageUrl = imageResult.Data.FullName;
                var result = await _productService.AddAsync(productAddDto, LoggedInUser.UserName);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    ViewData["Message"] = $"{result.Message}";                   
                    return View(productAddViewModel);
                    //return View(new ProductAddViewModel
                    //{
                    //    Categories = categorySelectList.Data.Categories,
                    //});
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(productAddViewModel);
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            var productResult = await _productService.GetProductUpdateDtoAsync(productId);
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            if (productResult.ResultStatus == ResultStatus.Success && categoriesResult.ResultStatus == ResultStatus.Success)
            {
                var productUpdateViewModel = Mapper.Map<ProductUpdateViewModel>(productResult.Data);
                productUpdateViewModel.Categories = categoriesResult.Data.Categories;
                return View(productUpdateViewModel);
            }
            return NotFound();
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)
        {          
            if (ModelState.IsValid)
            {              
                bool isNewImageUploaded = false;
                var oldImage = productUpdateViewModel.ImageUrl;
                if (productUpdateViewModel.ImageUrlFile != null)
                {
                    var uploadedImageResult = await ImageHelper.Upload(productUpdateViewModel.Name, productUpdateViewModel.ImageUrlFile, PictureType.Product);
                    productUpdateViewModel.ImageUrl = uploadedImageResult.ResultStatus == ResultStatus.Success
                        ? uploadedImageResult.Data.FullName
                        : "productImages/defaultImage.png";
                    if (oldImage != "productImages/defaultImage.png")
                    {
                        isNewImageUploaded = true;
                    }
                }              
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(productUpdateViewModel);               
                var result = await _productService.UpdateAsync(productUpdateDto, LoggedInUser.UserName);               

                if (result.ResultStatus == ResultStatus.Success)
                {
                    if (isNewImageUploaded)
                    {
                        ImageHelper.Delete(oldImage);
                    }
                    ViewData["Message"] = $"{result.Message}";
                    var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
                    productUpdateViewModel.Categories = categoriesResult.Data.Categories;
                    return View(productUpdateViewModel);                   
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var categoriesResult2 = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            productUpdateViewModel.Categories = categoriesResult2.Data.Categories;
            return View(productUpdateViewModel);
            // Güncelleme yaparken yeni resım eklendıgınde eskisi silinmiyor?
        }

        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> Delete(int productId)
        {
            //var result = await _productService.DeleteAsync(productId,LoggedInUser.UserName);
            //var productResult = JsonSerializer.Serialize(result);
            //return Json(productResult);

            var result = await _productService.DeleteAsync(productId, LoggedInUser.UserName);
            var productResult = JsonSerializer.Serialize(result);
            return Json(productResult);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int productId)
        {
            var result = await _productService.HardDeleteAsync(productId);
            var hardDeletedProductResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedProductResult);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int productId)
        {
            var result = await _productService.UndoDeleteAsync(productId, LoggedInUser.UserName);
            var undoDeleteProductResult = JsonSerializer.Serialize(result);
            return Json(undoDeleteProductResult);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> DeletedProducts()
        {
            var products = await _productService.GetAllByDeletedAsync();
            return View(products.Data);
        }
    }
}
