using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DashBoard
{
    public class _LocationComponent(ICarService _carService,IMapper _mapper) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll();
            var carsDto = _mapper.Map<List<ResultListCarDto>>(cars)
                .OrderByDescending(b => b.CarId)
                .Take(6).ToList();
            return View(carsDto);
        }
    }
}
