using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Services;

namespace NLayer.Web.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public NavigationViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            return View(new CategoryListDto
            {
                Categories = categoriesResult.Data.Categories
            });
        }
    }
}
