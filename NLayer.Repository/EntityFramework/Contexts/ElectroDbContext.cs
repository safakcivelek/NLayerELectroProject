using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Concert;
using NLayer.Core.OtherEntities;
using NLayer.Repository.EntityFramework.MappingConfigurations;
using NLayer.Repository.EntityFramework.Seeds;

namespace NLayer.Repository.EntityFramework.Contexts
{
    // IdentityDbContext<> içerisinde sadece User,Rol,int olarak'da verebilirdim ancak diğer sınıflarda özelleştirmeler yapacağım için o sınıflarıda buraya ekliyorum. (IdentityDbContext<User, Role, int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>)
    // Özelleştirmeler => mapping vb.
    public class ElectroDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {       
        public ElectroDbContext(DbContextOptions<ElectroDbContext> options) : base(options)
        {       
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Mapping
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new OrderDetailMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserTokenMap());
            builder.ApplyConfiguration(new LogMap());

            // Seed
            builder.ApplyConfiguration(new CategorySeed());
            builder.ApplyConfiguration(new ProductSeed());
            builder.ApplyConfiguration(new OrderSeed());
            builder.ApplyConfiguration(new OrderDetailSeed());
            builder.ApplyConfiguration(new CommentSeed());
            builder.ApplyConfiguration(new UserSeed());
            builder.ApplyConfiguration(new RoleSeed());
            builder.ApplyConfiguration(new UserRoleSeed());

            base.OnModelCreating(builder);
        }
        // *** Identy  User-Role !!! Tamamlanınca burayı silebilirim. ***
        // Asp.Net Cote Identity yapısını projeme ekledim.
        // Context'im artık DbContext'den değil IdentityDbContext<> 'den miras alıyor.
        // =>Microsoft.AspNetCore.Identity.EntityFrameworkCore kütüphanesini NLayerRepository katmanıma yükledim.
        // =>Microsoft.Extensions.Identity.Stores kütüphanesini Core katmanıma yükledim.
        // User ve Role sınıflarım ile ilgi bazı kısımları kaldırdım ve bu sınıflarda değişiklikler yaptım.
        // UserRole isimli yeni bir sınıf ekledim. Çoka çok ilişkiyi temsil edicek.
        // Eklenen sınıflar => UserRole,UserClaim,UserLogin,UserRole,UserToken,RoleClaim
        // User-Role mapping işlemleri yapıldı. Microsoft'un sayfasından yardım alarak "Default model configuration" mapping işlemleri yapıldı.
        // =>Microsoft.AspNetCore.Identity kütüphanesi NLayerService katmanına yüklendi.
        // ServiceCollectionExtensions static sınıfımza Identity eklendi.
        // Migration uygulandı.
    }
}
