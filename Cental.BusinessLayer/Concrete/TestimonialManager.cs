using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        public TestimonialManager(IGenericDal<Testimonial> genericdal) : base(genericdal)
        {
        }
    }
}
