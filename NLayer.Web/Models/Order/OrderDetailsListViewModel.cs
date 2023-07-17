using NLayer.Core.Entities.Concert;
using NLayer.Core.Utilities.Results.ComplexTypes;

namespace NLayer.Web.Models.Order
{
    public class OrderDetailsListViewModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
        public string AddressTitle { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetailsViewModel> OrderDetailsViewModels { get; set; }
    }
    public class OrderDetailsViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public double SubTotal { get; set; }        
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }       
    }
    
}
