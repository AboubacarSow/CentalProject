using Cental.EntityLayer.Entities;

namespace Cental.DtoLayer.BookingDtos
{
    public class CreateBookingDto
    {
        public string ModelName { get; set; }
        public string PickUpLocation { get; set; }
        public string DropUpLocation { get; set; }
        public DateTime PickUpTime { get; set; }
        public string PickUpHour { get; set; }
        public DateTime DropOffTime { get; set; }
        public bool DateIsValid => PickUpTime>=DateTime.UtcNow && PickUpTime < DropOffTime;
        public string DropUpHour { get; set; }
        public int UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
