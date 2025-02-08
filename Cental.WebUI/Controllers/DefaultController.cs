using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController(IMessageService _messageManager) : Controller
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
    }
}
