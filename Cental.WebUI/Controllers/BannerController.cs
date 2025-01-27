using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class BannerController(IBannerService _bannerManager, IMapper _mapper) : Controller
    {
        
        public IActionResult Index()
        {
            var values=_bannerManager.TGetAll();
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
            _bannerManager.TCreate(banner);
            return View();
        }
    }
}
