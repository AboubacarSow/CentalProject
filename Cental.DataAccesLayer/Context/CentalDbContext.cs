using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccesLayer.Context
{
    public class CentalDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS01; Database=CentalDb;trustServerCertificate=true; Trusted_Connection=true;");
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }  
        public DbSet<MSocialMedia> MSocialMedias { get; set; }  
        public DbSet<CentalSocialPage> CentalSocialPages { get; set; }  
        public DbSet<Branch> Branches { get; set; }  
        public DbSet<Contact> Contacts{ get; set; }  
        public DbSet<Message> Messages{ get; set; }  
    }
}
