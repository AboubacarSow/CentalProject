namespace Cental.EntityLayer.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public string ModelName { get; set; }
        public string PickUpLocation { get; set; }
        public string DropUpLocation { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }
        public int UserId { get; set; }
    }
}
