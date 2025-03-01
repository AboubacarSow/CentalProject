using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BannerController(IBannerService _bannerService, IMapper _mapper) : Controller
    {
        
        public IActionResult Index()
        {
            var values= _bannerService.TGetAll();
            var model = _mapper.Map<List<ResultBannerDto>>(values);
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBannerDto bannerDto)
        {
            var banner = _mapper.Map<Banner>(bannerDto);
            _bannerService.TCreate(banner);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update ([FromRoute]int id)
        {
            var banner = _bannerService.TGetById(id);
            var bannerDto = _mapper.Map<UpdateBannerDto>(banner);
            return View(bannerDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateBannerDto bannerDto)
        {
            if (!ModelState.IsValid) return View(bannerDto);               
            var banner = _mapper.Map<Banner>(bannerDto);
            _bannerService.TUpdate(banner);
            return RedirectToAction("Index");
        }

        public IActionResult Delete([FromRoute] int id)
        {
            _bannerService.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
