using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class ServiceManager : GenericManager<Service>, IServiceService
    {
        public ServiceManager(IGenericDal<Service> genericdal) : base(genericdal)
        {
        }
    }
}
