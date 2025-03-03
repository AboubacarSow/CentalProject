using AutoMapper;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ReviewMapping : Profile
    {
        public ReviewMapping()
        {
            //More precision needed
            CreateMap<Review, ResultReviewDto>().ForMember(dest=>dest.ResultCarDto, opt=>opt.MapFrom(src=>src.Car));
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<CreateReviewDto, Review>();
                                                
        }
    }
}
