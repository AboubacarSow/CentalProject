﻿using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.CarDtos
{
    public class UpdateCarDto
    {
        public int CarId { get; set; }
        public required string ModelName { get; set; }
        public required string ImageUrl { get; set; }
        public required decimal Price { get; set; }
        public required int SeatCount { get; set; }
        public required string GearType { get; set; }
        public required string GasType { get; set; }
        public int Year { get; set; }
        public required string Transmission { get; set; }
        public int Kilometer { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
       
    }
}
