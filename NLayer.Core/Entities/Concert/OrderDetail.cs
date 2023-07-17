using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.Entities.Concert
{
    public class OrderDetail : IEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }      
        public double SubTotal { get; set; } 

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
