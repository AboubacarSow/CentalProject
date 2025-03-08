using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminDashboardController(IBrandService _brandService,
        IBranchService _branchService,
        IMessageService _messageSevice,
        IServiceService _service,
        ITestimonialService _testimonialService,
        ICarService _carService,
        IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            GetTotalBrand();
            GetTotalBranch();
            GetTotalServices();
            GetTotalMessages();
            GetTotalRating();
            var cars = _carService.TGetAll();
            var carsDto = _mapper.Map<List<ResultListCarDto>>(cars)
                .OrderByDescending(b => b.CarId)
                .Take(6).ToList();
            return View(carsDto);
        }
        private void GetTotalBrand()
        {
            ViewBag.Brands = _brandService.TGetAll().Count;
        }
        private void GetTotalBranch()
        {
            ViewBag.Branches = _branchService.TGetAll().Count;
        }
        private void GetTotalServices()
        {
            ViewBag.Services = _service.TGetAll().Count;
        }
        private void GetTotalMessages()
        {
            ViewBag.Emails = _messageSevice.TGetAll().Count;
        }
        private void GetTotalRating()
        {
            ViewBag.Rating = _testimonialService.TGetAll().Count;
        }
    }
}
