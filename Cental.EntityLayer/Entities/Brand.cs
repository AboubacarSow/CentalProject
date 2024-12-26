using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }    
        public required string BrandName { get; set; }    
        public required List<Car> Cars { get; set; }
    }
}
