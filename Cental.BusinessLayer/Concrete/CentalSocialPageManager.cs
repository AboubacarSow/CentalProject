

using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class CentalSocialPageManager : GenericManager<CentalSocialPage>, ICentalSocialPageService
    {
        public CentalSocialPageManager(IGenericDal<CentalSocialPage> genericdal) : base(genericdal)
        {
        }
    }
}
