﻿using AutoMapper;
using Cental.DtoLayer.MessageDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class MessageMapping : Profile
    {
        public  MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>();
            CreateMap<CreateMessageDto, Message>();
        }
    }
}
