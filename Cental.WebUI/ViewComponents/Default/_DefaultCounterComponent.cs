using Cental.BusinessLayer.Abstract;

using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCounterComponent(ITestimonialService _testimonialService,
        ICarService _carService, IBranchService _branchService) :ViewComponent
    {
       
        
        public IViewComponentResult Invoke()
        {
            ViewBag.Likes = _testimonialService.TGetAll().Count;
            ViewBag.Branches = _branchService.TGetAll().Count;
            ViewBag.Cars = _carService.TGetAll().Count;
            var car = _carService.TGetAll()
                .OrderByDescending(x => x.Kilometer)
                .Take(1).FirstOrDefault();
            ViewBag.Kilometers = car.Kilometer;
                
            return View();
        }
    }
}
