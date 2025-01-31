using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.Enums.Car_Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carManager;
        private readonly IMapper _mapper;
        private readonly IBrandService _brandManager;


        public CarController(ICarService carManager, IMapper mapper,IBrandService brandManager)
        {
            _carManager = carManager;
            _mapper = mapper; 
            _brandManager = brandManager;
        }

        private void GetSelectListItems()
        {
            ViewBag.Gastypes = GetEnumValues.GetValues<GasType>();
            ViewBag.GearTypes = GetEnumValues.GetValues<GearType>();
            ViewBag.Transmissions = GetEnumValues.GetValues<Transmission>();
            var ListBrands = _brandManager.TGetAll();
            ViewBag.Brands=(from brand in ListBrands
                                select new SelectListItem()
                                {
                                    Text = brand.BrandName,
                                    Value = brand.BrandId.ToString()
                                }).ToList() ;

        }
        public IActionResult Index()
        {
            var cars = _carManager.TGetAll();
            var carsDto=_mapper.Map<List<ResultListCarDto>>(cars);  
            return View(carsDto);
        }
        [HttpGet]
        public IActionResult Create()
        {
            GetSelectListItems();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCarDto carDto)
        {
            var car= _mapper.Map<Car>(carDto);
            _carManager.TCreate(car);
            return RedirectToAction("Index");
        }
    }
}
