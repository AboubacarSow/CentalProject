using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class BookingManager : GenericManager<Booking>, IBookingService
    {
        public BookingManager(IGenericDal<Booking> genericdal) : base(genericdal)
        {
        }
    }
}
