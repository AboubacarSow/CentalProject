using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SocialPageDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminSocialPageController : Controller
    {
        private readonly ICentalSocialPageService _pageService;
        private readonly IMapper _mapper;

        public AdminSocialPageController(IMapper mapper, ICentalSocialPageService pageService)
        {
            _mapper = mapper;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            var pages = _pageService.TGetAll();
            var pageDtos = _mapper.Map<List<ResultSocialPageDto>>(pages);
            return View(pageDtos);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSocialPageDto pageDto)
        {
            if (!ModelState.IsValid)
                return View(pageDto);
            var page = _mapper.Map<CentalSocialPage>(pageDto);
            _pageService.TCreate(page);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update([FromRoute]int id)
        {
            var page = _pageService.TGetById(id);
            var pageDto = _mapper.Map<UpdateSocialPageDto>(page);
            return View(pageDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateSocialPageDto pageDto)
        {
            if (!ModelState.IsValid)
                return View(pageDto);
            var page = _mapper.Map<CentalSocialPage>(pageDto);
            _pageService.TUpdate(page);
            return RedirectToAction("Index");
        }
        public IActionResult Delete (int id)
        {
            _pageService.TDelete(id);
            return RedirectToAction("Index");
        }

        
    }
}
