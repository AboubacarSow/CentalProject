using AutoMapper;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using System.Data;

namespace Cental.WebUI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            int thisYear=DateTime.Now.Year;
            CreateMap<About, ResultListAboutDto>().ForMember(d=>d.ExperienceYear,op=>op.MapFrom(s=>thisYear-s.StartYear));
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

        }
    }
}
