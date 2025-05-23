﻿using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _SetBookingComponent(IBrandService _brandService) : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Brands = (from brand in _brandService.TGetAll()
                              select new SelectListItem
                              {
                                  Text = brand.BrandName,
                                  Value = brand.BrandName
                              }).ToList();
            ViewData["id"] = id;
            return View();
        }
    }
}
