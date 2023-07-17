using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Areas.Admin.Models;
using NLayer.Web.Helpers.Abstract;
using System.Text.Json;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {      
        private readonly SignInManager<User> _signInManager;                     

        public UserController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IImageHelper imageHelper):base(userManager,mapper,imageHelper)
        {           
            _signInManager = signInManager;          
        }

        [Authorize(Roles = "FullAccess")]
        public async Task<IActionResult> Index()
        {
            var users = await UserManager.Users.ToListAsync();          
            var userListDto = new UserListDto
            {
                Users = users,
                ResultStatusBase = ResultStatus.Success,

            };
            return View(userListDto);
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        //DÜZENLE ÇALŞMIYOR.
        public async Task<IActionResult> GetDetail(int userId)
        {
            var user = await UserManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                return PartialView("_DetailPartial", new UserDto { User = user });
            }
            return NotFound();
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
               var uploadedImageDtoResult = await ImageHelper.Upload(userAddDto.UserName, userAddDto.PictureFile,PictureType.User);
                userAddDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success ? uploadedImageDtoResult.Data.FullName 
                    : "userImages/defaultUser.png";
                var user = Mapper.Map<User>(userAddDto);
                var result = await UserManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddViewModel = new UserAddViewModel
                    {
                        UserDto = new UserDto
                        {
                            User = user,
                            ResultStatusBase = ResultStatus.Success,
                            MessageBase = $"{user.UserName} adlı kullanıcı başarıyla eklenmiştir."
                        },                       
                    };
                    ViewData["Message"] = $"{userAddViewModel.UserDto.MessageBase}";
                    return View(userAddViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    var userAddErrorViewModel = new UserAddViewModel
                    {
                        UserAddDto = userAddDto                       
                    };
                    ViewData["Message"] = "Kullanıcı ekleme işlemi başarısız oldu.";
                    return View(userAddErrorViewModel);
                }
            }
            var userAddModelStateErrorViewModel = new UserAddViewModel
            {
                UserAddDto = userAddDto
            };
            return View(userAddModelStateErrorViewModel);
        }

        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await UserManager.FindByIdAsync(userId.ToString());
            var result = await UserManager.DeleteAsync(user);
            
            if (result.Succeeded)
            {
                if (user.Picture != "userImages/defaultUser.png")
                    ImageHelper.Delete(user.Picture);

                var deletedUser =JsonSerializer.Serialize( new UserDto
                {
                    User = user,
                    ResultStatusBase = ResultStatus.Success,
                    MessageBase = $"{user.UserName} adlı kullanıcı başarıyla silinmiştir."
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMessages =String.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages=$"*{error.Description}\n";
                }
                var deletedUserErrorModel = JsonSerializer.Serialize(new UserDto
                {
                     ResultStatusBase= ResultStatus.Error,
                     MessageBase= $"{user.UserName} adlı kullanıcı silinirken bazı hatalar oluştu. \n{errorMessages}",
                     User=user
                });
                return Json(deletedUserErrorModel);
            }
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Update(int userId)
        {
            var user = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var userUpdateDto = Mapper.Map<UserUpdateDto>(user);

            var userUpdateViewModel = new UserUpdateViewModel
            {
                 UserUpdateDto = userUpdateDto,
            };
            return View(userUpdateViewModel);
        }
        [Authorize(Roles = "FullAccess")]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            // HATA ! => resim kayıt başarısız olunca da img klasörüne ekleniyor!!
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await UserManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile, PictureType.User);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success ? uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }
                }
                var updatedUser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageHelper.Delete(oldUserPicture);                     
                    }
                    var userUpdateViewModel = new UserUpdateViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatusBase = ResultStatus.Success,
                            MessageBase = $"{updatedUser.UserName} adlı kullanıcı başarıyla güncellenmiştir.",
                            User = updatedUser
                        }, 
                        UserUpdateDto= userUpdateDto
                    };
                    ViewData["Message"] = $"{userUpdateViewModel.UserDto.MessageBase}";
                    return View(userUpdateViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var userUpdateErrorViewModel = new UserUpdateViewModel
                    {                        
                        UserUpdateDto = userUpdateDto
                    };
                    ViewData["Message"] = $"{updatedUser.UserName} adlı kullanıcının güncelleme işlemi başarısız oldu.";
                    return View(userUpdateErrorViewModel);
                }
            }
            else
            {
                var userUpdateModelStateErrorViewModel = new UserUpdateViewModel
                {
                    UserUpdateDto = userUpdateDto
                };
                return View(userUpdateModelStateErrorViewModel);
            }
        }

        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")] // Güvenlik açığı olabilir.
        [HttpGet]
        public async Task<ViewResult> ProfilEdit(int userId)
        {           
            var user = await UserManager.GetUserAsync(HttpContext.User);           
            var updateDto = Mapper.Map<UserUpdateDto>(user);          
            return View(updateDto);
        }
        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")] // Güvenlik açığı olabilir.
        [HttpPost]
        public async Task<ViewResult> ProfilEdit(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await UserManager.GetUserAsync(HttpContext.User);
                var oldUserPicture = oldUser.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await ImageHelper.Upload(userUpdateDto.UserName, userUpdateDto.PictureFile, PictureType.User);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Success ? uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }                   
                }
                var updatedUser = Mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await UserManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        ImageHelper.Delete(oldUserPicture);
                    }                   
                    ViewData["MessageSuccess"] = $"{updatedUser.UserName} adlı kullanıcı başarıyla güncellenmiştir.";
                    return View(userUpdateDto);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(userUpdateDto);
                }
            }
            else
            {
                return View(userUpdateDto);
            }
        }

        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")] // Güvenlik açığı olabilir.
        [HttpGet]
        public ViewResult PasswordEdit()
        {
            return View();
        }
        [Authorize(Roles = "FullAccess,ReadOnly,LoggedCustomer")] // Güvenlik açığı olabilir.
        [HttpPost]
        public async Task<IActionResult> PasswordEdit(UserPasswordEditDto userPasswordEditDto)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.GetUserAsync(HttpContext.User);
                var isVerified = await UserManager.CheckPasswordAsync(user, userPasswordEditDto.CurrentPassword);
                if (isVerified)
                {
                    var result = await UserManager.ChangePasswordAsync(user, userPasswordEditDto.CurrentPassword, userPasswordEditDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await UserManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userPasswordEditDto.NewPassword, true,false);
                        ViewData["MessageSuccess"] = "Şifreniz başarıyla değiştirilmiştir.";
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(userPasswordEditDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen, şu anki şifrenizi doğru giriniz.");
                    return View(userPasswordEditDto);
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen, şu anki şifrenizi doğru giriniz.");
                return View(userPasswordEditDto);
            }           
        }       
    }
}
