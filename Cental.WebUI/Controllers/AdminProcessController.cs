using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminProcessController(IProcessService _processService,
        IMapper _mapper): Controller
    {
        public IActionResult Index()
        {
            var processes = _processService.TGetAll();
            var processDtos = _mapper.Map<List<ResultProcessDto>>(processes);
            return View(processDtos);
        }
        public IActionResult Delete(int id)
        {
            _processService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProcessDto processDto)
        {
            if (!ModelState.IsValid)
                return View(processDto);
            var process = _mapper.Map<Process>(processDto);
            _processService.TCreate(process);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var process = _processService.TGetById(id);
            return View(_mapper.Map<UpdateProcessDto>(process));
        }
        [HttpPost]
        public IActionResult Update(UpdateProcessDto procDto)
        {
            if (!ModelState.IsValid)
                return View(procDto);
            var process = _mapper.Map<Process>(procDto);
            _processService.TUpdate(process);
            return RedirectToAction("Index");
        }

    }
}
