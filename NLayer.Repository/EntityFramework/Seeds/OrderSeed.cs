using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Utilities.Results.ComplexTypes;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {          
            builder.HasData(
                new Order
                {
                    Id = 1,
                    UserId = 3,
                    //AddressId = 1,
                    UserName= "customeruser",
                    Description = "1 No'lu Sipariş Açıklaması.",
                    AddressTitle="Ev",
                    Address = "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul",
                    Country="Türkiye",
                    City="İstanbul",
                    District="Küçükçekmece",
                    PostalCode="34660",
                    Status = OrderStatus.ReceivedOrder,
                    OrderNumber="No1111",
                    Total= 350,                  
                    IsActive = false,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Order
                {
                    Id = 2,
                    UserId = 3,
                    //AddressId = 2,
                    UserName = "customeruser",
                    Description = "2 No'lu Sipariş Açıklaması.",
                    AddressTitle = "Ev",
                    Address = "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2.",
                    Country = "Belçika",
                    City = "Brüksel",
                    District = "Üsküdar",
                    PostalCode = "34660",
                    Status = OrderStatus.ReceivedOrder,
                    OrderNumber = "No2222",
                    Total = 950,

                    IsActive = false,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Order
                {
                    Id = 3,
                    UserId = 3,
                    UserName = "customeruser",
                    //AddressId = 2,
                    Description = "3 No'lu Sipariş Açıklaması.",
                    AddressTitle = "İş",
                    Address = "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul",
                    Country = "Japonya",
                    City = "Tokyo",
                    District = "Kadiköy",
                    PostalCode = "34660",
                    Status = OrderStatus.ReceivedOrder,
                    OrderNumber="No3333",
                    Total =1700,

                    IsActive = false,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Order
                {
                    Id = 4,
                    UserId = 3,
                    UserName = "customeruser",
                    //AddressId = 2,
                    Description = "4 No'lu Sipariş Açıklaması.",
                    AddressTitle = "İş",
                    Address = "Kanarya mahallesi. Şahin caddesi. Kırlangıç sokak. No/11. Kat/2. Küçükçekmece/İstanbul",
                    Country = "Fransa",
                    City = "Paris",
                    District = "Beylikdüzü",
                    PostalCode = "34660",
                    Status = OrderStatus.ReceivedOrder,
                    OrderNumber = "No4444",
                    Total=2630,

                    IsActive = false,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                });               
        }       
    }
}
