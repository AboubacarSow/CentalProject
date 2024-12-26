using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Testimonial
    {
        public int Id { get; set; } 
        public string FullName {  get; set; }  
        public string Title {  get; set; }  
        public string Comment {  get; set; }    
        public string UrlImage {  get; set; } 
        public int Review {  get; set; }    
    }
}
