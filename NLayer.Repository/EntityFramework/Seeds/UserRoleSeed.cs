using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                // FullAccess
                new UserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                // ReadOnly
                new UserRole
                {
                    UserId = 1,
                    RoleId = 2
                },
                // LoggedCustomer
                new UserRole
                {
                    UserId = 1,
                    RoleId = 3
                },
                // NotLoggedCustomer               
                new UserRole
                {
                    UserId = 1,
                    RoleId = 4
                },               
                // ReadOnly
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                },
                // LoggedCustomer
                new UserRole
                {
                    UserId = 2,
                    RoleId = 3
                },
                // NotLoggedCustomer
                new UserRole
                {
                    UserId = 2,
                    RoleId = 4
                },                                      
                // LoggedCustomer
                new UserRole
                {
                    UserId = 3,
                    RoleId = 3
                },
                // NotLoggedCustomer
                new UserRole
                {
                    UserId = 3,
                    RoleId = 4
                });
        }
    }
}
                      
    

 