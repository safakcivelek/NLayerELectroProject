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
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService,UserManager<User> userManager,IMapper mapper,IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllByNonDeletedAsync();           
            return View(categories.Data);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.AddAsync(categoryAddDto, LoggedInUser.UserName);
                if (category.ResultStatus == ResultStatus.Success)
                {
                    var categoryAddViewModel = new CategoryAddViewModel
                    {
                        CategoryAddDto = categoryAddDto,
                    };
                    ViewData["Message"] = $"{category.Message}";
                    return View(categoryAddViewModel);
                }               
            }
            var categoryAddErrorViewModel = new CategoryAddViewModel
            {
                CategoryAddDto = categoryAddDto,
            };
            return View(categoryAddErrorViewModel);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId) 
        {
            var result = await _categoryService.GetCategoryUpdateDtoAsync(categoryId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var categoryUpdateViewModel = new CategoryUpdateViewModel
                {
                    CategoryUpdateDto = result.Data
                };
                return View(categoryUpdateViewModel);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.UpdateAsync(categoryUpdateDto, LoggedInUser.UserName);
                if (category.ResultStatus == ResultStatus.Success)
                {
                    var categoryUpdateViewModel = new CategoryUpdateViewModel
                    {
                        CategoryDto = category.Data,
                        CategoryUpdateDto = categoryUpdateDto,
                    };
                    ViewData["Message"] = $"{category.Message}";
                    return View(categoryUpdateViewModel);
                }
                if (category.ResultStatus == ResultStatus.Error)
                {
                   // Olmayan bir ID dışardan verilip güncelleme yapıldığında bu kontrol yapılacak.
                    var categoryUpdateErrorViewModel2 = new CategoryUpdateViewModel
                    {
                        CategoryUpdateDto = categoryUpdateDto,
                    };
                    ViewData["Message"] = $"{category.Message}";
                    return View(categoryUpdateErrorViewModel2);
                }
            }
            var categoryUpdateErrorViewModel = new CategoryUpdateViewModel
            {
                CategoryUpdateDto = categoryUpdateDto,
            };
            return View(categoryUpdateErrorViewModel);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> Delete(int categoryId)
        {
            var result  = await _categoryService.DeleteAsync(categoryId, LoggedInUser.UserName);
            // result.Data yerine sadece result'ı json olarak değerini goremiyorum ?
            // Result tipini json olarak dönebiliyorum fakat DataResult<> olan generic tipi json olarak karşılığını view tarafında alamıyorum !!
            var deletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }     
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int categoryId)
        {
            var result = await _categoryService.HardDeleteAsync(categoryId);
            var deletedCategory = JsonSerializer.Serialize(result);
            return Json(deletedCategory);
        }       
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int categoryId)
        {
            var result = await _categoryService.UndoDeleteAsync(categoryId, LoggedInUser.UserName);            
            var undoDeletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(undoDeletedCategory);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> DeletedCategories()
        {
            var categories = await _categoryService.GetAllByDeletedAsync();
            return View(categories.Data);
        }
    }
}
