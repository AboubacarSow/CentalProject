using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public AdminMessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var messages = _messageService.TGetAll();
            var messageDtos = _mapper.Map<List<ResultMessageDto>>(messages);
            return View(messageDtos);
        }

        public IActionResult Delete ([FromRoute]int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult SetAsRead(int id)
        {
            var messageResult = _messageService.TGetById(id);
            messageResult.IsRead = true;
            _messageService.TUpdate(messageResult);
            return RedirectToAction("Index");
        }
    }
}
