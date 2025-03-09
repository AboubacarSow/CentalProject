using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminBookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public AdminBookingController(IMapper mapper, IBookingService bookingService)
        {
            _mapper = mapper;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<ResultBookingDto>>(_bookingService.TGetAll()));
        }
    }
}
