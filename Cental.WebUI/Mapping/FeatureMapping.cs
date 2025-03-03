using AutoMapper;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class FeatureMapping :Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<CreateFeatureDto, Feature>();
        }
    }
}
