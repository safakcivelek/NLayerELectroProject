using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NLayer.Core.Entities.Concert;
using NLayer.Core.OtherEntities;
using NLayer.Repository.EntityFramework.Contexts;
using NLayer.Service.AutoMapper.MappingProfiles;
using NLayer.Service.Extensions;
using NLayer.Web.AutoMapper.MappingProfiles;
using NLayer.Web.Filters;
using NLayer.Web.Helpers;
using NLayer.Web.Helpers.Abstract;
using NLayer.Web.Helpers.Concrete;
using NLog.Web;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
//using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/* Nlog */
builder.Logging.ClearProviders();
builder.Logging.AddNLog("nlog.config");

/* SmtpSettings */
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

/* AddRazorRuntimeCompilation()=> bu iþlem sayesinde her deðiþiklikte uygulamamýzý tekrar derlememize gerek kalmýyor. */
builder.Services.AddControllersWithViews(options =>
{
	/*  Null olamaz mesajýný tüm uyglamada türkçeleþtirmiþ oldum. */
	options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan boþ geçilmemelidir.");
	/* Eklemiþ olduðum Filter'ýn aktif bir þekilde çalýþmasýný saðladým. */
	//options.Filters.Add<MvcExceptionFilter>(); // Þimdilik Pasife aldým hatalarýmý görebilmek için aktife çekeceðim.

}).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
			{
				opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
			});

/* Kullanýcý server'a girdiðinde oluþan oturum. */
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

/* AutoMapper */
/* Burada assembly sine göre mapleri eklemek daha mantýklý çünkü farklý assembly'lerde ayný isimda map'isimleri olabilir. */
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(UserProfile), typeof(ProductProfile), typeof(CommentProfile), typeof(OrderProfile), typeof(ViewModelsProfile));

/* DI */
builder.Services.LoadMyServices(connectionString: builder.Configuration.GetConnectionString("SqlConnection"));

/* Img */
builder.Services.AddScoped<IImageHelper, ImageHelper>();

builder.Services.ConfigureApplicationCookie(options =>
{
	/* Logine yönlendirir. */
	options.LoginPath = new PathString("/Admin/Auth/UserLogin");
	options.LogoutPath = new PathString("/Admin/Auth/Logout");
	options.Cookie = new CookieBuilder
	{
		Name = "Electro",
		// HttpOnly => Cookie bilgilermize baþkalarý tarafýndan ulaþýlmasýný engeller.
		HttpOnly = true,
		// SameSite => Cookie bilgilerinin geldiði adresi,siteyi vb. kontrol eder. 
		SameSite = SameSiteMode.Strict,
		// SecurePolicy => Cooki'lerin güvenlik aktarým yollarý ,http,https vb...
		SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
	};
	options.SlidingExpiration = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(7);
	// AccessDeniedPath => Sistem içeriside giriþ yapmýþ fakat yetkisi olmayan bir alana de giriþ yapmaya çalýþan kullanýcý için.
	options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

// Css,js,img
app.UseStaticFiles();
app.UseRouting();
// Kimlik kontrolü
app.UseAuthentication();
// Yetki kontrolü
app.UseAuthorization();

app.UseSession();

app.MapAreaControllerRoute(
	name: "Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
	 //name: "Default",
	 //pattern: "{controller=Home}/{action=Index}/{id?}");
	 name: "Default",
	 pattern: "{controller}/{action}/{id?}",
	 defaults: new { controller = "Home", action = "Index" }
	   );
app.MapControllerRoute(
	 name: "Default",
	 pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
