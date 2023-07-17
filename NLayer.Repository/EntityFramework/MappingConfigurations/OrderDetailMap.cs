using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.MappingConfigurations
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => new { od.ProductId, od.OrderId });
            builder.Property(od => od.SubTotal).HasColumnType("decimal(18,2)");
            builder.Property(od => od.SubTotal).IsRequired();
            builder.Property(od => od.Price).HasColumnType("decimal(18,2)");
            builder.Property(od => od.Price).IsRequired();
            builder.Property(od => od.Quantity).HasColumnType("smallint");
            builder.Property(od => od.Quantity).IsRequired();          
            builder.Property(od => od.IsActive).IsRequired();
            builder.Property(od => od.IsDeleted).IsRequired();
            builder.Property(od => od.CreatedDate).IsRequired();
            builder.Property(od => od.ModifiedDate).IsRequired();
            builder.Property(od => od.CreatedByName).IsRequired();
            builder.Property(od => od.CreatedByName).HasMaxLength(50);
            builder.Property(od => od.ModifiedDate).IsRequired();
            builder.Property(od => od.ModifiedDate).HasMaxLength(50);

            builder.ToTable("OrderDetails");
        }
    }
}
