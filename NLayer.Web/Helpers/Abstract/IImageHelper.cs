using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;

namespace NLayer.Web.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile,PictureType pictureType, string folderName=null);
        IDataResult<ImageDeleteDto> Delete(string pictureName);
    }
}
