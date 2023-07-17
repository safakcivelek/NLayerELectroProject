using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Concert;
using NLayer.Web.Areas.Admin.Models;

namespace NLayer.Web.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user =await _userManager.GetUserAsync(HttpContext.User);
            var roles =await _userManager.GetRolesAsync(user);
            if (user == null)
                return Content("Kullanıcı bulunamadı!");
            if (roles == null)
                return Content("Roller bulunamadı!");
            return View(new UserWithRolesViewModel
            {
                User= user,
                Roles=roles
            });
        }
    }
}
