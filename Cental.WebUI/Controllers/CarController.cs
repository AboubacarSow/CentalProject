using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carManager;
        private readonly IMapper _mapper;


        public CarController(ICarService carManager, IMapper mapper)
        {
            _carManager = carManager;
            _mapper = mapper;   
        }

        
        public IActionResult Index()
        {
            var cars = _carManager.TGetCarsWithBrand();
            var carsDto=_mapper.Map<List<ResultListCarDto>>(cars);  
            return View(carsDto);
        }
    }
}
