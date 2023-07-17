using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Results.Abstract;

namespace NLayer.Service.OtherServices.Abstract
{
    public interface IMailService
    {
        IResult Send(EmailSendDto emailSendDto);
        IResult SendContactEmail(EmailSendDto emailSendDto);
    }
}
