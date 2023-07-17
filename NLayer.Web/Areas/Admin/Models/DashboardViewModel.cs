using NLayer.Core.DTOs.Concert;

namespace NLayer.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int OrdersCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public int ProductsCount { get; set; } 
        public  ProductListDto Products { get; set; } // Son eklenen ürünler Listesi.    
    }
}
