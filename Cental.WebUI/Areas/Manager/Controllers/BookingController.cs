using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles="Manager")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        private IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var booking = _bookingService.TGetAll();
            return View(_mapper.Map<List<ResultBookingDto>>(booking));
        }
        [HttpPost]
        public IActionResult SetAsApproved([FromBody] int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsApproved = true;
            _bookingService.TUpdate(booking);
            return Json(new { success = true, message = "Kiralama talebi başarıyla onaylandı" });
        }
    }
}
