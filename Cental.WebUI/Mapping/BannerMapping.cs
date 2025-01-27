using AutoMapper;
using Cental.DtoLayer.BannerDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<Banner,CreateBannerDto>().ReverseMap();
            CreateMap<Banner,UpdateBannerDto>().ReverseMap();
            CreateMap<Banner, ResultBannerDto>().ReverseMap();
        }
    }
}
