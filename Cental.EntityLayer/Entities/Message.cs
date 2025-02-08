using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.EntityLayer.Entities
{
    public class Message
    {
        public int Id { get; set; } 
        public string FullName { get; set; }    
        public string Email {  get; set; }
        public string Subject {  get; set; }    
        public string Body { get; set; }
        public bool IsRead { get; set; } = false;

    }
}
