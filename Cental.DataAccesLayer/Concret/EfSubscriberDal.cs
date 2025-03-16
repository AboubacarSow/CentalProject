using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;


namespace Cental.DataAccesLayer.Concret
{
    public class EfSubscriberDal : GenericRepository<Subscriber>, ISubscriberDal
    {
        public EfSubscriberDal(CentalDbContext context) : base(context)
        {
        }
    }
}
