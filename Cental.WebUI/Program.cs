using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Concret;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using System.Reflection;

namespace Cental.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CentalDbContext>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());    

            builder.Services.AddScoped<IAboutService,AboutManager>();
            builder.Services.AddScoped<IAboutDal,EfAboutDal>();

            builder.Services.AddScoped<IBannerService,BannerManager>();
            builder.Services.AddScoped<IBannerDal,EfBannerDal>();

            builder.Services.AddScoped<IBrandService, BrandManager>();
            builder.Services.AddScoped<IBrandDal,EfBrandDal>(); 

            builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));



            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
