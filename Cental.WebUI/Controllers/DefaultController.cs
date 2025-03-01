using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            if (TempData["filterCars"] != null)
            {
                var data = TempData["filterCars"].ToString();
                if (data != null)
                {

                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });



                    return View(filterCars);

                }
            }

            var values = _carManager.TGetAll();
            return View(values); ;  
        }
        [HttpPost]
        public IActionResult FilterCars(string brand,string gear,string gas, int year)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable();
            if(!string.IsNullOrEmpty(brand))
                values=values.Where(b=>b.Brand.BrandName==brand);  
            if(!string.IsNullOrEmpty(gear)) 
                values=values.Where(g=>g.GearType==gear);   
            if(!string.IsNullOrEmpty(gas))
                values=values.Where(g=>g.GasType==gas); 
            if(year>0)
                values=values.Where(g=>g.Year>=year);

            var filteredcars = values.ToList();
            TempData["filterCars"] = JsonSerializer.Serialize(filteredcars, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return RedirectToAction("Cars");

        }
       
        
    }
}
