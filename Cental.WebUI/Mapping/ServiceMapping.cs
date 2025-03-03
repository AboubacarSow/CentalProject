using AutoMapper;
using Cental.DtoLayer.ServiceDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ServiceMapping: Profile
    {
        public ServiceMapping()
        {
            CreateMap<Service, ResultServiceDto>();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<CreateServiceDto, Service>();
        }
    }
}
