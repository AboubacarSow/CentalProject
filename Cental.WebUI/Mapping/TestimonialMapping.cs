using AutoMapper;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class TestimonialMapping :Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDto>();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>();
        }
    }
}
