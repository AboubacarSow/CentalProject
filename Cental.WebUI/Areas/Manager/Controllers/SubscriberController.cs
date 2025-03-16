using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SubscriberDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    public class SubscriberController(ISubscriberService _subscriberService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var subscriberDtos = _mapper.Map<List<ResultSubscriberDto>>(_subscriberService.TGetAll());
            return View(subscriberDtos);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _subscriberService.TDelete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
