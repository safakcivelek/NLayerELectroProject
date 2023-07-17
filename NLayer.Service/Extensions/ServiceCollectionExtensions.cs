using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.EntityFramework.Contexts;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.OtherServices.Abstract;
using NLayer.Service.OtherServices.Concrete;
using NLayer.Service.Services;

namespace NLayer.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ElectroDbContext>(x => x.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));              
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<ICommentService, CommentManager>();

            /* AddHttpContextAccessor =>
             * Client'dan gelen request neticesinde oluşturulan HttpContext nesnesine katmanlardaki class'lar üzerinden(busineess logic) erişebilmemizi sağlayan bir servistir.
             */          
            services.AddHttpContextAccessor();
            services.AddSingleton<IMailService, MailManager>();
            services.AddIdentity<User, Role>(options =>
            {
                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ElectroDbContext>();
            return services;
        }
    }
}
