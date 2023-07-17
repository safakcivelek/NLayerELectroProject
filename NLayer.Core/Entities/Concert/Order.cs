using NLayer.Core.Entities.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;

namespace NLayer.Core.Entities.Concert
{
    public class Order : BaseEntity, IEntity
    {       
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

        public User User { get; set; }        
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
