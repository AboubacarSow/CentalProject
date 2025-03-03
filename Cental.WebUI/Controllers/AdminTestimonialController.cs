using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public AdminTestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {
            _mapper = mapper;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            var testimonials = _testimonialService.TGetAll();
            var testimonialDtos = _mapper.Map<List<ResultTestimonialDto>>(testimonials);
            return View(testimonialDtos);
        }
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto testimonialDto)
        {
            if (!ModelState.IsValid)
                return View(testimonialDto);
            var testimonial = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.TCreate(testimonial);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            var testimonialDto = _mapper.Map<UpdateTestimonialDto>(testimonial);
            return View(testimonialDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateTestimonialDto testimonialDto)
        {
            if (!ModelState.IsValid)
                return View(testimonialDto);
            var testimonial = _mapper.Map<Testimonial>(testimonialDto);
            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
    }
}
