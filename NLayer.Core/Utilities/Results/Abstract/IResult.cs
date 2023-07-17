using NLayer.Core.OtherEntities;
using NLayer.Core.Utilities.Results.ComplexTypes;

namespace NLayer.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get;  }
        public string Message { get;  }      
        public Exception Exception { get; }

        // Birden çok validasyon hatası olabilir o yüzden Liste olarak veriyorum.
        // Ayrıca IEnumarable yapmamın diğer bir sebebi ise dışardan düzenlenmesini engellemek.
        // Örneğin; Validation.Add işlemi çalışmayacak çünkü IEnumarable bu işlemi desteklemiyor. 
        // Yani birkere oluştuğunda tam haliyle oluşacak, sonrasında düzenlenmeyecektir.
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
