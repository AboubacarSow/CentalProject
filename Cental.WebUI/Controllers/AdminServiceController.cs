using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IServiceService _manager;
        private readonly IMapper _mapper;

        public AdminServiceController(IMapper mapper, IServiceService manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public IActionResult Index()
        {
            var services = _manager.TGetAll();
            var serviceDtos = _mapper.Map<List<ResultServiceDto>>(services);
            return View(serviceDtos);
        }
        public IActionResult Delete(int id)
        {
            _manager.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
                return View(serviceDto);
            var service = _mapper.Map<Service>(serviceDto);
            _manager.TCreate(service);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var service = _manager.TGetById(id);
            var serviceDto = _mapper.Map<UpdateServiceDto>(service);
            return View(serviceDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
                return View(serviceDto);
            var service = _mapper.Map<Service>(serviceDto);
            _manager.TUpdate(service);
            return RedirectToAction("Index");
        }

    }
}
