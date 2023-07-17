using NLayer.Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Abstract
{   
    public abstract class GetBaseDto
    {
        public virtual ResultStatus ResultStatusBase { get; set; }
        public virtual string MessageBase { get; set; }
        /*==========================================================================*/

        // Eğer bir sayfa verilmez ise birinci sayfadan başlamak istiyorum.
        public virtual int CurrentPage { get; set; } = 1;
        // Bir sayfa içerisinde kaç tane değer göstermek istediğim alan.
        public virtual int PageSize { get; set; } = 6;
        // Toplam Ürün Sayısı.
        public virtual int TotalCount { get; set; }
        // Toplam sayfa sayısını verir.
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        // Önceki Butonu için.(1. sayfada isem daha önceki bir sayfaya gidemem.)
        public virtual bool ShowPrevious => CurrentPage > 1;
        // Sonraki Butonu için.
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = true;
    }
}
