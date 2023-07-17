using NLayer.Core.Entities.Concert;

namespace NLayer.Web.Models.Cart
{ 
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines { get { return _cartLines; } }
        public void AddProduct(Product product, short quantity)
        {
            var line = _cartLines.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine() { Quantity = quantity, Product = product });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(x => x.Product.Id == product.Id);
        }
        public double Total()
        {
            return _cartLines.Sum(x => Convert.ToDouble(x.Product.Price) * x.Quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
    }
}
