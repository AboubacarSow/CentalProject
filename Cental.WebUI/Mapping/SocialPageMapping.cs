using AutoMapper;
using Cental.EntityLayer.Entities;
using Cental.DtoLayer.SocialPageDtos;

namespace Cental.WebUI.Mapping
{
    public class SocialPageMapping : Profile
    {
        public SocialPageMapping()
        {
            CreateMap<CentalSocialPage, ResultSocialPageDto>();
            CreateMap<CentalSocialPage, CreateSocialPageDto>().ReverseMap();
            CreateMap<CentalSocialPage, UpdateSocialPageDto>().ReverseMap();
        }
    }
}
