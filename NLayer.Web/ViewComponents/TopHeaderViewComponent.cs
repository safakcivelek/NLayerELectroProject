using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NLayer.Core.Entities.Concert;
using NLayer.Web.Models;

namespace NLayer.Web.ViewComponents
{
    public class TopHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public TopHeaderViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (user == null)
            {
                return View(new LoggedInUserViewModel
                {
                    User = null,
                    Roles=null
                });
            }
            else 
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.IsNullOrEmpty())
                {
                    return View(new LoggedInUserViewModel
                    {
                        User = user,
                        Roles = null
                    });
                }                     
                return View(new LoggedInUserViewModel
                {
                    User = user,
                    Roles = roles
                });
            }                   
        }
    }
}
