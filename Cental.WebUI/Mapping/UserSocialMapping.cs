using AutoMapper;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class UserSocialMapping : Profile
    {
        public UserSocialMapping()
        {
            CreateMap<MSocialMedia, ResultUserSocialDto>();
            CreateMap<MSocialMedia, CreateUserSocialDto>().ReverseMap();
            CreateMap<MSocialMedia, UpdateUserSocialDto>().ReverseMap();
        }
    }
}
