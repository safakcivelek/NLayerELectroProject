using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class OrderDetailSeed : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = 1,
                ProductId = 1,
                Price = 10,
                Quantity = 11,              
                SubTotal = 0,               
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail.SubTotal = (Convert.ToDouble(orderDetail.Price) * orderDetail.Quantity);

            var orderDetail2 = new OrderDetail
            {
                OrderId = 1,
                ProductId = 2,
                Price = 20,
                Quantity = 12,               
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail2.SubTotal = (Convert.ToDouble(orderDetail2.Price) * orderDetail2.Quantity);

            var orderDetail3 = new OrderDetail
            {
                OrderId = 2,
                ProductId = 3,
                Price = 30,
                Quantity = 13,               
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail3.SubTotal = (Convert.ToDouble(orderDetail3.Price) * orderDetail3.Quantity);

            var orderDetail4 = new OrderDetail
            {
                OrderId = 2,
                ProductId = 4,
                Price = 40,
                Quantity = 14,
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail4.SubTotal = (Convert.ToDouble(orderDetail4.Price) * orderDetail4.Quantity);

            var orderDetail5 = new OrderDetail
            {
                OrderId = 3,
                ProductId = 5,
                Price = 50,
                Quantity = 15,
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail5.SubTotal = (Convert.ToDouble(orderDetail5.Price) * orderDetail5.Quantity);

            var orderDetail6 = new OrderDetail
            {
                OrderId = 3,
                ProductId = 6,
                Price = 60,
                Quantity = 16,
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail6.SubTotal = (Convert.ToDouble(orderDetail6.Price) * orderDetail6.Quantity);

            var orderDetail7 = new OrderDetail
            {
                OrderId = 4,
                ProductId = 7,
                Price = 70,
                Quantity = 17,
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail7.SubTotal = (Convert.ToDouble(orderDetail7.Price) * orderDetail7.Quantity);

            var orderDetail8 = new OrderDetail
            {
                OrderId = 4,
                ProductId = 8,
                Price = 80,
                Quantity = 18,
                SubTotal = 0,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate"
            };
            orderDetail8.SubTotal = (Convert.ToDouble(orderDetail8.Price) * orderDetail8.Quantity);

            builder.HasData(orderDetail,orderDetail2,orderDetail3,orderDetail4,orderDetail5,orderDetail6,orderDetail7,orderDetail8);
        }       
    }
}
