using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.CarDtos;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public AdminReviewController(IMapper mapper, IReviewService reviewService, ICarService carService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var reviews = _reviewService.TGetAll();
            var reviewDtos = _mapper.Map<List<ResultReviewDto>>(reviews);
            return View(reviewDtos);
        }

        public IActionResult Delete(int id)
        {
            _reviewService.TDelete(id);
            return RedirectToAction("Index");
        }
        private void GetCars()
        {
            ViewBag.Cars = (from car in _carService.TGetAll()
                            select new SelectListItem
                            {
                                Text=car.ModelName,
                                Value=car.CarId.ToString()
                            }).ToList();
        }

        public IActionResult Create()
        {
            GetCars();
            return View();

        }
        [HttpPost]
        public IActionResult Create(CreateReviewDto reviewDto)
        {
            var car = _carService.TGetCarById(reviewDto.CarId, false);
            reviewDto.ResultCarDto = _mapper.Map<ResultListCarDto>(car);
            if (!ModelState.IsValid)
            {
                GetCars();
                return View(reviewDto);
            }
            var review = _mapper.Map<Review>(reviewDto);
            _reviewService.TCreate(review);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update([FromRoute]int id)
        {
            GetCars();
            var review = _reviewService.TGetById(id);
            var reviewDto = _mapper.Map<UpdateReviewDto>(review);
            return View(reviewDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateReviewDto reviewDto)
        {
            var car = _carService.TGetCarById(reviewDto.CarId, false);
            reviewDto.ResultCarDto = _mapper.Map<ResultListCarDto>(car);
            if (!ModelState.IsValid)
            {
                GetCars();
                return View(reviewDto);
            }
            var review = _mapper.Map<Review>(reviewDto);
            _reviewService.TUpdate(review);
            return RedirectToAction("Index");

        }



    }
}
