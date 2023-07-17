using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Extensions;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Core.Utilities.Results.Concert;
using NLayer.Web.Helpers.Abstract;
using System.Text.RegularExpressions;

namespace NLayer.Web.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private const string imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string productImagesFolder = "productImages";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;           
            _wwwroot = _env.WebRootPath;
        }
      
        public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile,PictureType pictureType, string folderName = null)
        {
            /* Eğer folderName değişkeni null gelir ise, o zaman resim tipine göre (PictureType) klasör adı ataması yapılır. */
            folderName ??= pictureType == PictureType.User ? userImagesFolder : productImagesFolder;

            /* Eğer folderName değişkeni ile gelen klasör adı sistemimizde mevcut değilse, yeni bir klasör oluşturulur. */
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                /* Gerekli klasörün oluşması sağlanıyor. */
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }

            /* Resimin yüklenme sırasındaki ilk adı oldFileName adlı değişkene atanır. */
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);

            /* Resimin uzantısı fileExtension adlı değişkene atanır. */
            string fileExtension = Path.GetExtension(pictureFile.FileName);

            /* Ürün isminde özel karakterler olması durumunda ürün adının oluşması ve saklanmasından sonra, ürün görseli düzgün çalışmıyor.Bu sorunu     "Regex" sınıfı ile belirtilen özel karakterlerin girilmesi durumunda onların silinmesini sağlayarak bu sorunu çözmüş oluyorum. Bu silnen karakterler dosyan
               ın isminin oluştuğu folder alanından siliniyor.
             */
            Regex regex = new Regex("[*'\",._&#^@]");
            name = regex.Replace(name, string.Empty);

            DateTime dateTime = DateTime.Now;
            /*
            // Parametre ile gelen değerler kullanılarak yeni bir resim adı oluşturulur.
            // Örn: SafakCivelek_587_5_38_12_3_10_2023.png
            */
            string newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtension}";

            /* Kendi parametrelerimiz ile sistemimize uygun yeni bir dosya yolu (path) oluşturulur. */
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);

            /* Sistemimiz için oluşturulan yeni dosya yoluna resim kopyalanır. */
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            /* Resim tipine göre kullanıcı için bir mesaj oluşturulur. */
            string message = pictureType == PictureType.User 
                ? $"{name} adlı kullanıcının resimi başarıyla yüklenmiştir." 
                : $"{name} adlı ürünün resimi başarıyla yüklenmiştir.";

            return new DataResult<ImageUploadedDto>(ResultStatus.Success, message, new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }

        public IDataResult<ImageDeleteDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeleteDto = new ImageDeleteDto
                {
                    FullName = pictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeleteDto>(ResultStatus.Success, "Resim başarıyla silindi.", imageDeleteDto);
            }
            else
            {
                return new DataResult<ImageDeleteDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.", null);
            }
        }
    }
}
