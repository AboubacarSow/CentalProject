using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultCarCategoryComponent(ICarService _carService, IMapper _mapper) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll();
            var cardto = _mapper.Map<List<ResultListCarDto>>(cars).OrderByDescending(x => x.CarId).Take(6).ToList();
            return View(cardto);
        }
    }
}
