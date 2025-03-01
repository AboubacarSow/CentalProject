using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;

namespace Cental.DataAccesLayer.Concret
{
    public class EfBranchDal : GenericRepository<Branch>, IBranchDal
    {
        public EfBranchDal(CentalDbContext context) : base(context)
        {
        }
    }
}
