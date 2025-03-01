using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;


namespace Cental.DataAccesLayer.Concret
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(CentalDbContext context) : base(context)
        {
        }
    }
}
