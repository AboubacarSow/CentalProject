using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.Enums.Car_Enums;
using Cental.WebUI.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.CarFilter
{
    public class _CarFilterComponent 
        (ICarService _carService,IBrandService _brandService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Brands = (from brand in _brandService.TGetAll()
                            select new SelectListItem
                            {
                                Text = brand.BrandName,
                                Value = brand.BrandName
                            }).ToList();
            ViewBag.Gastypes = GetEnumValues.GetValues<GasType>();
            ViewBag.Geartypes = GetEnumValues.GetValues<GearType>();
            return View();
        }
    }
}
