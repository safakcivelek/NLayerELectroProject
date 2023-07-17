using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Concert;

namespace NLayer.Repository.EntityFramework.Seeds
{
    internal class RoleSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
            new Role
            {
                Id = 1,
                Name = "FullAccess",
                NormalizedName = "FULLACCESS",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
                new Role
                {
                    Id = 2,
                    Name = "ReadOnly",
                    NormalizedName = "READONLY",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
            new Role
            {
                Id = 3,
                Name = "LoggedCustomer",
                NormalizedName = "LOGGEDCUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = 4,
                Name = "NotLoggedCustomer",
                NormalizedName = "NOTLOGGEDCUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
