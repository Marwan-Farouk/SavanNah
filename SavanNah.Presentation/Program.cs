using Microsoft.EntityFrameworkCore;
using SavanNah.Business.Managers.BrandManager;
using SavanNah.Business.Managers.CategoryManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Brands;
using SavanNah.DataAccess.Repositories.Categories;
using SavanNah.DataAccess.Repositories.CategoryProducts;
using SavanNah.DataAccess.Repositories.Products;

namespace SavanNah.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseSqlServer(builder.Configuration.GetConnectionString("Savanah"));
        });

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryProductRepository, CategoryProductRepository>();
        builder.Services.AddScoped<IProductManager, ProductManager>();
        builder.Services.AddScoped<IBrandManager, BrandManager>();
        builder.Services.AddScoped<ICategoryManager, CategoryManager>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapAreaControllerRoute(
                name: "default",
                areaName: "User",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
