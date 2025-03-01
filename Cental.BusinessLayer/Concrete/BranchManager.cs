

using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class BranchManager : GenericManager<Branch>, IBranchService
    {
        public BranchManager(IGenericDal<Branch> genericdal) : base(genericdal)
        {
        }
    }
}
