using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;

namespace Cental.DataAccesLayer.Concret
{
    public class EfProcessDal : GenericRepository<Process>, IProcessDal
    {
        public EfProcessDal(CentalDbContext context) : base(context)
        {
        }
    }
}
