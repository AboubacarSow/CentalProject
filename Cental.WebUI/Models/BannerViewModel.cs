using Cental.DtoLayer.BannerDtos;
using Cental.DtoLayer.BookingDtos;

namespace Cental.WebUI.Models
{
    public class BannerViewModel
    {
        public List<ResultBannerDto> Banners { get; set; }
        public CreateBookingDto Booking { get; set; }
    }
}
