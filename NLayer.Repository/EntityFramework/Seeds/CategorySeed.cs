using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "Laptop Modelleri",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
               new Category
               {
                   Id = 2,
                   Name = "Kamera",
                   Description = "Kamera Modelleri",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   CreatedByName = "InitialCreate",
                   ModifiedByName = "InitialCreate"
               },
               new Category
               {
                   Id = 3,
                   Name = "Kulaklık",
                   Description = "Kulaklık Modelleri",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   CreatedByName = "InitialCreate",
                   ModifiedByName = "InitialCreate"
               },
               new Category
               {
                   Id = 4,
                   Name = "Monitor",
                   Description = "Monitor Modelleri",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   CreatedByName = "InitialCreate",
                   ModifiedByName = "InitialCreate"
               });               
        }
    }
}
