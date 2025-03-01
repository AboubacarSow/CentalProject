using Cental.BusinessLayer.Extensions;
using Cental.BusinessLayer.Validators;
using Cental.BusinessLayer.Validators.ErrorDescriber;
using Cental.DataAccesLayer.Context;
using Cental.EntityLayer.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cental.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddDbContext<CentalDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            //The best
           // builder.Services.AddDbContext<CentalDbContext>();   

            builder.Services.AddIdentity<AppUser,AppRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
               

            }).AddEntityFrameworkStores<CentalDbContext>()
              .AddErrorDescriber<CustumErrorDescriber>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddServicesConfiguration();

            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<BrandValidator>();

            builder.Services.AddControllersWithViews(option =>
            {
                option.Filters.Add(new AuthorizeFilter());
            });
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.LogoutPath = "/Login/Logout";
                options.AccessDeniedPath = "/ErrorPage/AccessDenied";
            });

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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/NotFoundedPage");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Profile}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
