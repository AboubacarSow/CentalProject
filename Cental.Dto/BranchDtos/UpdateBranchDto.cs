using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.BranchDtos
{
    public class UpdateBranchDto
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
