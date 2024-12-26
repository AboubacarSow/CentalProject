using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public required string ModelName { get; set; }   
        public required string ImageUrl {  get; set; }   
        public required decimal Price { get; set; }  
        public required int SeatCount { get; set; }
        public required string GearType {  get; set; }   
        public required string GasType {  get; set; }    
        public int Year {  get; set; }  
        public required string Transmission {  get; set; }
        public int Kilometer {  get; set; }
        public int BrandId {  get; set; }   
        public Brand Brand { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
