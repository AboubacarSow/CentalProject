using AutoMapper;
using Cental.DtoLayer.SubscriberDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class SubscriberMapping: Profile
    {
        public SubscriberMapping()
        {
            CreateMap<Subscriber, ResultSubscriberDto>();
            CreateMap<CreateSubscriberDto, Subscriber>();
            CreateMap<Subscriber, UpdateSubscriberDto>().ReverseMap();
            
        }
    }
}
