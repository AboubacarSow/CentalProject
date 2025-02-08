using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.MessageDtos
{
    public record CreateMessageDto(string FullName,string Email,string Subject,string Body);
    
    
}
