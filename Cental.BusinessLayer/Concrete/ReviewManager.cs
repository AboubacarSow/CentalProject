using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class ReviewManager : GenericManager<Review>, IReviewService
    {
        public ReviewManager(IGenericDal<Review> genericdal) : base(genericdal)
        {
        }
    }
}
