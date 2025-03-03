using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BrandDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandManager, IMapper mapper)
        {
            _brandService = brandManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_brandService.TGetAll());
        }
        public IActionResult Delete(int id)
        {
            _brandService.TDelete(id);
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
            if(!ModelState.IsValid) return View(brandDto);

            var brand=_mapper.Map<Brand>(brandDto);
            _brandService.TCreate(brand);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var brandDto = _mapper.Map<UpdateBrandDto>
                (_brandService.TGetById(id));
            return View(brandDto);
        }

        [HttpPost]
        public IActionResult Update(UpdateBrandDto brandDto)
        {
            if (!ModelState.IsValid) return View(brandDto);      
            var brand = _mapper.Map<Brand>(brandDto);
            _brandService.TUpdate(brand);
            return RedirectToAction("Index");
        }
    }
}
