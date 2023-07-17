using NLayer.Core.DTOs.Concert;

namespace NLayer.Web.Models
{
    public class HomeIndexViewModel
    {
        public ProductListDto ProductsWithCategory { get; set; }
        public CategoryListDto Categories { get; set; }
        public ProductListDto NewProducts { get; set; }
        public ProductListDto BestSellersProducts { get; set; }
        public ProductListDto TrendProducts { get; set; }
    }
}
