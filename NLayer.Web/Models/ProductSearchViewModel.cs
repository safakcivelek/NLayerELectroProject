using NLayer.Core.DTOs.Concert;

namespace NLayer.Web.Models
{
    public class ProductSearchViewModel
    {
        public ProductListDto ProductListDto { get; set; }
        public string Keyword { get; set; }
    }
}
