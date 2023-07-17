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

/* AddRazorRuntimeCompilation()=> bu i�lem sayesinde her de�i�iklikte uygulamam�z� tekrar derlememize gerek kalm�yor. */
builder.Services.AddControllersWithViews(options =>
{
	/*  Null olamaz mesaj�n� t�m uyglamada t�rk�ele�tirmi� oldum. */
	options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan bo� ge�ilmemelidir.");
	/* Eklemi� oldu�um Filter'�n aktif bir �ekilde �al��mas�n� sa�lad�m. */
	//options.Filters.Add<MvcExceptionFilter>(); // �imdilik Pasife ald�m hatalar�m� g�rebilmek i�in aktife �ekece�im.

}).AddRazorRuntimeCompilation().AddJsonOptions(opt =>
			{
				opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
			});

/* Kullan�c� server'a girdi�inde olu�an oturum. */
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

/* AutoMapper */
/* Burada assembly sine g�re mapleri eklemek daha mant�kl� ��nk� farkl� assembly'lerde ayn� isimda map'isimleri olabilir. */
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(UserProfile), typeof(ProductProfile), typeof(CommentProfile), typeof(OrderProfile), typeof(ViewModelsProfile));

/* DI */
builder.Services.LoadMyServices(connectionString: builder.Configuration.GetConnectionString("SqlConnection"));

/* Img */
builder.Services.AddScoped<IImageHelper, ImageHelper>();

builder.Services.ConfigureApplicationCookie(options =>
{
	/* Logine y�nlendirir. */
	options.LoginPath = new PathString("/Admin/Auth/UserLogin");
	options.LogoutPath = new PathString("/Admin/Auth/Logout");
	options.Cookie = new CookieBuilder
	{
		Name = "Electro",
		// HttpOnly => Cookie bilgilermize ba�kalar� taraf�ndan ula��lmas�n� engeller.
		HttpOnly = true,
		// SameSite => Cookie bilgilerinin geldi�i adresi,siteyi vb. kontrol eder. 
		SameSite = SameSiteMode.Strict,
		// SecurePolicy => Cooki'lerin g�venlik aktar�m yollar� ,http,https vb...
		SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
	};
	options.SlidingExpiration = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(7);
	// AccessDeniedPath => Sistem i�eriside giri� yapm�� fakat yetkisi olmayan bir alana de giri� yapmaya �al��an kullan�c� i�in.
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
// Kimlik kontrol�
app.UseAuthentication();
// Yetki kontrol�
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
