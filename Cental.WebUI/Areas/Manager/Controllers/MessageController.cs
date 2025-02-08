using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles ="Manager")]
    public class MessageController(IMessageService _messageManager) : Controller
    {
        public IActionResult Index()
        {
           var messages= _messageManager.TGetAll();
            var messageDtos=messages.Adapt<List<ResultMessageDto>>();   
            return View(messageDtos);
        }
    }
}
