﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }   
        public string Title {  get; set; }  
        public string Description { get; set; } 
        public string? ImageUrl {  get; set; }   
    }
}
