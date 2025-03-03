﻿using AutoMapper;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mapping
{
    public class CarMapping :Profile
    {
        public CarMapping()
        {
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
            CreateMap<Car, ResultListCarDto>().ReverseMap();
        }
    }
}
