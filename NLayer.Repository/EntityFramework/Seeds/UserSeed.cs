using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var adminUser = new User
            {
                Id=1,
                UserName="adminuser",
                NormalizedUserName="ADMINUSER",
                Email="adminuser@gmail.com",
                NormalizedEmail="ADMINUSER@GMAIL.COM",
                PhoneNumber="+905555555555",
                Picture = "userImages/defaultUser.png",
                FirstName = "Admin",
                LastName = "User",
                About = "Admin User of Electro",
                TwitterLink = "https://twitter.com/adminuser",
                InstagramLink = "https://instagram.com/adminuser",
                YoutubeLink = "https://youtube.com/adminuser",
                GitHubLink = "https://github.com/adminuser",
                LinkedInLink = "https://linkedin.com/adminuser",
                WebsiteLink = "https://electro.com/",
                FacebookLink = "https://facebook.com/adminuser",
                EmailConfirmed =true,
                PhoneNumberConfirmed=true,
                SecurityStamp=Guid.NewGuid().ToString()                                
            };
            adminUser.PasswordHash = CreatePasswordHash(adminUser, "adminuser");
            var editorUser = new User
            {
                Id = 2,
                UserName = "editoruser",
                NormalizedUserName = "EDITORUSER",
                Email = "editoruser@gmail.com",
                NormalizedEmail = "EDITORUSER@GMAIL.COM",
                PhoneNumber = "+905555555555",
                Picture = "userImages/defaultUser.png",
                FirstName = "Editor",
                LastName = "User",
                About = "Editor User of Electro",
                TwitterLink = "https://twitter.com/editoruser",
                InstagramLink = "https://instagram.com/editoruser",
                YoutubeLink = "https://youtube.com/editoruser",
                GitHubLink = "https://github.com/editoruser",
                LinkedInLink = "https://linkedin.com/editoruser",
                WebsiteLink = "https://electro.com/",
                FacebookLink = "https://facebook.com/editoruser",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            editorUser.PasswordHash = CreatePasswordHash(editorUser, "editoruser");

            var customer = new User
            {
                Id = 3,
                UserName = "customeruser",
                NormalizedUserName = "CUSTOMERUSER",
                Email = "customeruser@gmail.com",
                NormalizedEmail = "CUSTOMERUSER@GMAIL.COM",
                PhoneNumber = "+905555555555",
                Picture = "userImages/defaultUser.png",
                FirstName = "Customer",
                LastName = "User",
                About = "Customer User of Electro",
                TwitterLink = "https://twitter.com/customeruser",
                InstagramLink = "https://instagram.com/customeruser",
                YoutubeLink = "https://youtube.com/customeruser",
                GitHubLink = "https://github.com/customeruser",
                LinkedInLink = "https://linkedin.com/customeruser",
                WebsiteLink = "https://electro.com/",
                FacebookLink = "https://facebook.com/customeruser",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            customer.PasswordHash = CreatePasswordHash(customer, "customeruser");

            builder.HasData(adminUser, editorUser,customer);
        }
        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
