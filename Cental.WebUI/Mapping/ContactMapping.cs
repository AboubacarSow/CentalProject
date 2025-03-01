using AutoMapper;
using Cental.DtoLayer.ContactDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class ContactMapping :Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<CreateContactDto, Contact>();

        }
    }
}
