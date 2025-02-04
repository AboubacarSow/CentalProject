using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.UserSocialDtos
{
    public class UpdateUserSocialDto
    {
 
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int UserId { get; set; }
    }
}
