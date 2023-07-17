using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Concert;
using NLayer.Web.Helpers.Abstract;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        /*================================================================================================================================*/
        /* Tüm field'ları get olarak ayarladım çünkü bunların başka sınıflar tarafından değiştirilmesini istemiyorum. */
        protected UserManager<User> UserManager { get; }
        protected IMapper Mapper { get; }
        protected IImageHelper ImageHelper  { get; }
        /* 
         * GetUserAsync asenkron bir metot olduğu için sonunda .Result eklemeliyim. 
         * Artık BaseController'dan türemiş sınıflarda  Login olmuş kullanıcının bilgilerine erişmek istdiğimde LoggedInUser'ı kullanacağım.
         */
        protected User LoggedInUser => UserManager.GetUserAsync(HttpContext.User).Result;
        /*===============================================================================================================================*/

        public BaseController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper)
        {
            UserManager = userManager;
            Mapper = mapper;
            ImageHelper = imageHelper;
        }
    }
}
