using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class About
    {
        public int AboutId { get; set; }    
        public string Vision {  get; set; } 
        public string Mission {  get; set; }    
        public string Description { get; set; }
        public string Description1 { get; set; } 
        public int StartYear {  get; set; }
        public string ImageUrl {  get; set; }
        public string ImageUrl1 {  get; set; }
        public string Item1 { get; set; } 
        public string Item2 { get; set; }
        public string Item3 { get; set; }   
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string ProfileImage {get; set;}  

    }
}
