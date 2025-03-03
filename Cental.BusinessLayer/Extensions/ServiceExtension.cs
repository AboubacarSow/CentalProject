using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Concret;
using Cental.DataAccesLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cental.BusinessLayer.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<IBannerDal, EfBannerDal>();
            
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDal, EfBrandDal>();  
            
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICarDal, EfCarDal>(); 
            
            services.AddScoped<IUserSocialService, UserSocialManager>();
            services.AddScoped<IUserSocialDal, EfUserSocial>();

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();
            
            services.AddScoped<IBranchDal, EfBranchDal>();
            services.AddScoped<IBranchService, BranchManager>();
            
            services.AddScoped<ICentalSocialPageDal, EfCentalSocialPageDal>();
            services.AddScoped<ICentalSocialPageService, CentalSocialPageManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IProcessDal, EfProcessDal>();
            services.AddScoped<IProcessService, ProcessManager>();

            services.AddScoped<IReviewDal, EfReviewDal>();
            services.AddScoped<IReviewService, ReviewManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            

            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IImageService, ImageManager>();
        }
    }
}
