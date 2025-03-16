using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SubscriberDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminSubscriberController(ISubscriberService _subscriberService,IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var subscriberDtos = _mapper.Map<List<ResultSubscriberDto>>(_subscriberService.TGetAll());
            return View(subscriberDtos);
        }
        public IActionResult Delete([FromRoute]int id)
        {
            _subscriberService.TDelete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
