using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BookingDtos
{
    public class ResultBookingDto
    {
        public int BookingId { get; set; }
        public string ModelName { get; set; }
        public string PickUpLocation { get; set; }
        public string DropUpLocation { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DropOffTime { get; set; }
        public bool IsApproved { get; set; } = false;
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
