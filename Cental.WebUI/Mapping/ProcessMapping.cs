using AutoMapper;
using Cental.DtoLayer.ProcessDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ProcessMapping : Profile
    {
        public ProcessMapping()
        {
            CreateMap<Process, ResultProcessDto>();
            CreateMap<Process, UpdateProcessDto>().ReverseMap();
            CreateMap<CreateProcessDto,Process>();
        }
    }
}
