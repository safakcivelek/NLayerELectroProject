using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{  
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Casper Nirvana Intel Core i7",
                    Price = 10,
                    Stock = 10,
                    Description = "2 Yıl Garantili, Taşınabilir Bilgisayar",
                    ImageUrl = "productImages/defaultProduct1.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Canon XA11 FUll HD",
                    Price = 20,
                    Stock = 20,
                    Description = "2 Yıl Garantili, Taşınabilir Kamera",
                    ImageUrl = "productImages/defaultProduct3.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 3,
                    Name = "Sony WH-CH510W Kablosuz",
                    Price = 30,
                    Stock = 30,
                    Description = "2 Yıl Garantili, Taşınabilir Kulaklık",
                    ImageUrl = "productImages/defaultProduct4.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 4,
                    Name = "ASUS Rog 24.5 140Hz ",
                    Price = 40,
                    Stock = 40,
                    Description = "2 Yıl Garantili, Taşınabilir Monitor",
                    ImageUrl = "productImages/defaultProduct5.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    Name = "Hp Victus Intel Core i5",
                    Price = 50,
                    Stock = 50,
                    Description = "2 Yıl Garantili, Taşınabilir Bilgisayar",
                    ImageUrl = "productImages/defaultProduct2.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 2,
                    Name = "Haikon DA33 FUll HD",
                    Price = 60,
                    Stock = 60,
                    Description = "2 Yıl Garantili, Taşınabilir Kamera",
                    ImageUrl = "productImages/defaultProduct3.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Name = "SAMSUNG O-IA500B Kulaklık",
                    Price = 70,
                    Stock = 70,
                    Description = "2 Yıl Garantili, Taşınabilir Kulaklık",
                    ImageUrl = "productImages/defaultProduct4.png",
                    Discount = 50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedByName = "InitialCreate",
                    ModifiedByName = "InitialCreate"
                },
                new Product
                {
                    Id = 8,
                    CategoryId = 4,
                    Name = "MSI Optix G241VC 23.6 75Hz",
                    Price = 80,
                    Stock = 80,
                    Description = "2 Yıl Garantili, Taşınabilir Monitor",
                    ImageUrl = "productImages/defaultProduct5.png",
                    Discount=50 / 100,
                    IsDiscounted = false,
                    StarGivenUserCount = 10,
                    StarPoint = 5,
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
