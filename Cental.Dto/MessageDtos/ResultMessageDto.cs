using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cental.DtoLayer.MessageDtos
{
    public class ResultMessageDto 
    { 
        public int Id { get; set; }
        public  string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; }
    } 
   
    
    
}
