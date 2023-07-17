using NLayer.Core.Entities.Concert;

namespace NLayer.Web.Models.Cart
{
    public class CartLine
    {
        public Product Product { get; set; }
        public short Quantity { get; set; }
        public decimal SubTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }     
    }
}
