using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Web.Helpers.Abstract;
using System.Text.Json.Serialization;
using System.Text.Json;
using NLayer.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace NLayer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : BaseController
    {
        // View tarafında model nasıl gidiyor ??
        private readonly ICommentService _commentService;
        public CommentController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper, ICommentService commentService) : base(userManager, mapper, imageHelper)
        {
            _commentService = commentService;
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _commentService.GetAllByNonDeletedAsync();
            return View(result.Data);
        }

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> GetDetail(int commentId)
        {
            var result = await _commentService.GetAsync(commentId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_DetailPartial", result.Data);
            }
            return NotFound();
        }

        [Authorize(Roles = "FullAccess")]
        [HttpGet]
        public async Task<IActionResult> Update(int commentId)
        {
            var result = await _commentService.GetCommentUpdateDtoAsync(commentId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                var commentUpdateViewModel = new CommentUpdateViewModel
                {
                    CommentUpdateDto = result.Data
                };
                return View(commentUpdateViewModel);
            }
            return NotFound();
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpPost]
        public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.UpdateAsync(commentUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var commentUpdateViewModel = new CommentUpdateViewModel
                    {
                        CommentDto = result.Data,
                        CommentUpdateDto = commentUpdateDto
                    };
                    ViewData["Message"] = $"{result.Message}";
                    return View(commentUpdateViewModel);
                }
            }
            var commentUpdateErrorModel = new CommentUpdateViewModel
            {
                CommentUpdateDto = commentUpdateDto,
            };
            return View(commentUpdateErrorModel);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            var result = await _commentService.DeleteAsync(commentId, LoggedInUser.UserName);
            var commentResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(commentResult);
        }
        [Authorize(Roles = "FullAccess, ReadOnly")]
        [HttpPost]
        public async Task<JsonResult> HardDelete(int commentId)
        {
            var result = await _commentService.HardDeleteAsync(commentId);
            var hardDeletedProductResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(hardDeletedProductResult);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpPost]
        public async Task<JsonResult> UndoDelete(int commentId)
        {
            var result = await _commentService.UndoDeleteAsync(commentId, LoggedInUser.UserName);
            var undoDeleteCommentResult = JsonSerializer.Serialize(result,new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(undoDeleteCommentResult);
        }
        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpGet]
        public async Task<IActionResult> DeletedComments()
        {
            var comments = await _commentService.GetAllByDeletedAsync();
            return View(comments.Data);
        }

        /* Önemli NOT => Servisteki IDataResult dönüş tipinde olan; ResultStatus, Message, vb. durumlar...
         * JsonSerializer İnterfaceleri serileştiremiyor. Yani aşağıdaki; JsonSerializer.Serialize(result) kısmındaki (result) alanı IDataResult dönüyor.Buda bizim view tarafına IDataResult içrisindeki mesajı veya ResultStatusu json olarak taşımamızı engelliyor.
         * Buna çözüm olarak GetBasDto'larda Mesaj ve ResultStatus durumları için alan oluşturmuştum.Bunları GetBaseDto dan alarak bu sorunu çözebilirim.
         * Veya View tarafında Mesajı string olarak elle yazabilirim
         * Yine View tarafında commentResult'un ResultStatus durumunu kontrol etmek yerinn içerisinde data kontrolu yapabiliriz,
         * (if(commetnResult.Data)) gibi...
         */

        [Authorize(Roles = "FullAccess,ReadOnly")]
        [HttpPost]
        public async Task<IActionResult> Approve(int commentId)
        {
            var result = await _commentService.ApproveAsync(commentId, LoggedInUser.UserName);

            var commentResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(commentResult);
        }
    }
}
