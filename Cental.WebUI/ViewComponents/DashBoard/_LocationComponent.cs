using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.DashBoard
{
    public class _LocationComponent(IBookingService _bookingService,IMapper _mapper) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var bookings = _bookingService.TGetAll();
            var bookingDtos = _mapper.Map<List<ResultBookingDto>>(bookings)
                .OrderByDescending(b => b.BookingId)
                .Take(6).ToList();
            return View(bookingDtos);
        }
    }
}
