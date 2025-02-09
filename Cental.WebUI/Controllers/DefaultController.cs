using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DtoLayer.Enums.Car_Enums;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Infrastructure.Extensions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IMessageService _messageManager,
                ICarService _carManager,CentalDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage([FromBody]CreateMessageDto messageDto)
        {
            var message = messageDto.Adapt<Message>();
            if(ModelState.IsValid)
            {
                _messageManager.TCreate(message);
                return Json(new { success = true, message="Teşekküler! Size en kısa sürede cevap verilecektir" });
            }
            else
            {
                return Json(new { success = false, message = "Tekrar girdiğiniz bilgileri kontrol ediniz" });
            }
        }
        public IActionResult Cars()
        {
            var values = _carManager.TGetAll();
            var data = TempData["FilteredCars"].ToString();
            if (data != null)
            {
                values = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });
            }
            return View(values);  
        }
        public PartialViewResult FilterCars()
        {
            
            ViewBag.Cars = (from car in _carManager.TGetAll()
                              select new SelectListItem
                              {
                                  Text = car.Brand.BrandName + " " + car.ModelName,
                                  Value = car.Brand.BrandName + " " + car.ModelName
                              }).ToList();

            ViewBag.Models = (from model in _carManager.TGetAll()
                              select new SelectListItem
                              {
                                  Text = model.ModelName,
                                  Value = model.ModelName
                              }).ToList();
            ViewBag.Gastypes=GetEnumValues.GetValues<GasType>();
            ViewBag.Geartypes=GetEnumValues.GetValues<GearType>();
            return PartialView();

        }
        [HttpPost]
        public IActionResult FilterCars(string car, string gear, int year, string gas)
        {
            if(string.IsNullOrEmpty(car) || string.IsNullOrEmpty(gear)|| string.IsNullOrEmpty(gas)|| year>0)
            {
                var values = _context.Cars.Where(c => c.Brand.BrandName + " " + c.ModelName == car
                && c.GasType == gas
                && c.GearType==gear
                &&c.Year>=year).ToList();
                TempData["FilteredCars"] = JsonSerializer.Serialize(values, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles

                });
            }
            return RedirectToAction("Cars");
        }
    }
}
