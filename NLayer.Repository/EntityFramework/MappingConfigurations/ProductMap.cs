using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.MappingConfigurations
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,3)");
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(300);
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.Property(p => p.Discount);
            builder.Property(p=> p.IsDiscounted).IsRequired();
            builder.Property(p => p.StarGivenUserCount).IsRequired();
            builder.Property(p => p.StarPoint).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.ModifiedDate).IsRequired();
            builder.Property(p => p.CreatedByName).IsRequired();
            builder.Property(p => p.CreatedByName).HasMaxLength(50);
            builder.Property(p => p.ModifiedByName).IsRequired();
            builder.Property(p => p.ModifiedByName).HasMaxLength(50);                 

            builder.ToTable("Products");           
        }
    }
}
