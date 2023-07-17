using NLayer.Core.Entities.Concert;

namespace NLayer.Web.Models
{
    public class LeftSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Product> ProductsByPrice { get; set; }
    }
}
