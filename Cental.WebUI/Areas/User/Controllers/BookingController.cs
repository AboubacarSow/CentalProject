using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles ="User")]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper,UserManager<AppUser> userManager)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
           if(User.Identity is null || !User.Identity.IsAuthenticated)
           {
                return RedirectToAction("Index", "Login", new { area = "User" });
           }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var bookings = _bookingService.TGetAll().Where(b=>b.UserId==user.Id);
            return View(_mapper.Map<List<ResultBookingDto>>(bookings));
        }
        [HttpPost]
        public IActionResult CancelApplication([FromBody] int id)
        {
            var booking = _bookingService.TGetById(id);
            booking.IsValid = false;
            _bookingService.TUpdate(booking);
            return Json(new
            {
                success = true,
                message = "Talebiniz iptal edilmiştir!"
            });
        }

    }
}
