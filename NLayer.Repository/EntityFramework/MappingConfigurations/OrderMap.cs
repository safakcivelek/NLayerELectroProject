using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.MappingConfigurations
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(o => o.Description).IsRequired();
            builder.Property(o => o.Description).HasMaxLength(300);
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.AddressTitle).IsRequired();
            builder.Property(o => o.AddressTitle).HasMaxLength(50);
            builder.Property(o => o.Address).IsRequired();
            builder.Property(o => o.Address).HasMaxLength(300);
            builder.Property(o => o.Country).IsRequired();
            builder.Property(o => o.Country).HasMaxLength(50);
            builder.Property(o => o.City).IsRequired();
            builder.Property(o => o.City).HasMaxLength(50);
            builder.Property(o => o.District).IsRequired();
            builder.Property(o => o.District).HasMaxLength(100);
            builder.Property(o => o.PostalCode).IsRequired();
            builder.Property(o => o.PostalCode).HasMaxLength(5);
            builder.Property(o => o.OrderNumber).IsUnicode();
            builder.Property(o => o.OrderNumber).IsRequired();
            builder.Property(o => o.OrderNumber).HasMaxLength(6);
            builder.Property(o => o.Total).IsRequired();
            builder.Property(o => o.Total).HasColumnType("decimal(18,2)");

            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedDate).IsRequired();
            builder.Property(o => o.ModifiedDate).IsRequired();
            builder.Property(o => o.CreatedByName).IsRequired();
            builder.Property(o => o.CreatedByName).HasMaxLength(50);
            builder.Property(o => o.ModifiedByName).IsRequired();
            builder.Property(o => o.ModifiedByName).HasMaxLength(50);
            
            builder.Property(o => o.UserId).IsRequired();

            builder.ToTable("Orders");
        }
    }
}
