﻿using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AppUser, UserRegisterDto>().ReverseMap(); 
        }
    }
}
