using AutoMapper;
using Cental.DtoLayer.BranchDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class BranchMapping : Profile
    {
        public BranchMapping()
        {
            CreateMap<Branch, ResultBranchDto>();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
        }
    }
}
