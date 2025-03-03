using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class ProcessManager : GenericManager<Process>, IProcessService
    {
        public ProcessManager(IGenericDal<Process> genericdal) : base(genericdal)
        {
        }
    }
}
