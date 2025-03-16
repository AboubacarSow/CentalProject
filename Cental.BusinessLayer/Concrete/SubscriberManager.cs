using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;


namespace Cental.BusinessLayer.Concrete
{
    public class SubscriberManager : GenericManager<Subscriber>, ISubscriberService
    {
        public SubscriberManager(IGenericDal<Subscriber> genericdal) : base(genericdal)
        {
        }
    }
}
