using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandManager;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandManager, IMapper mapper)
        {
            _brandManager = brandManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_brandManager.TGetAll());
        }
        public IActionResult Delete(int id)
        {
            _brandManager.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult Create(CreateBrandDto brandDto)
        {
            //We will Change Brand to CreateBrandDto
            if(!ModelState.IsValid)
            {
                return View(brandDto);
            }
            var brand=_mapper.Map<Brand>(brandDto);
            _brandManager.TCreate(brand);
            return RedirectToAction("Index");
        }
    }
}
