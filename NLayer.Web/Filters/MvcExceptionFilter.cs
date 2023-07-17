using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NLayer.Core.OtherEntities;
using System.Data.SqlTypes;

namespace NLayer.Web.Filters
{
    /* Global Hata Yönetimi */
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ILogger _logger;

        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider, ILogger<MvcExceptionFilter> logger)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            /*
             * Geliştirme bittiğinde IsDevelopment=> IsProduction olarak ayarlancak.
             * Yani Production ortamına geçildiğinde buradaki kodlar işlenmesi sağlanacak.
             */
            if (_environment.IsDevelopment())
            {
                /* Hatanın kısmının ele alınma durumu ve artık bununla ilgili bir işlem yapıldığı anlamına geliyor. */
                context.ExceptionHandled = true;
                var mvcErrorModel = new MvcErrorModel();
                ViewResult result;
                /* Gelen Exception tipine göre sonuç verir. */
                switch (context.Exception)
                {
                    case SqlNullValueException:
                        mvcErrorModel.Message = $"Üzgünüz, işleminiz sırasında beklenmedik bir veritabanı hatası oluştu. Sorunu en kısa sürede çözeceğiz.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        result = new ViewResult { ViewName = "Error" }; // Error1View vb.
                        result.StatusCode = 500;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                    case NullReferenceException:
                        mvcErrorModel.Message = $"Üzgünüz, işleminiz sırasında beklenmedik bir null veriye rastlandı. Sorunu en kısa sürede çözeceğiz.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        result = new ViewResult { ViewName = "Error" }; // Error2View vb.
                        result.StatusCode = 403;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                    default:
                        mvcErrorModel.Message= $"Üzgünüz, işleminiz sırasında beklenmedik bir hata oluştu. Sorunu en kısa sürede çözeceğiz.";
                        mvcErrorModel.Detail=context.Exception.Message;
                        result=new ViewResult { ViewName = "Error" };
                        result.StatusCode = 500;
                        _logger.LogError(context.Exception, "Bu benim log hata mesajım!");
                        break;
                }
                /* Bir hata oluştuğundan dolayı artık kullanıcıya bir hata view'ının dönmesini istiyorum. */                               
                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);
                result.ViewData.Add("MvcErrorModel", mvcErrorModel);
                context.Result= result;   
            }
        }
    }
}
