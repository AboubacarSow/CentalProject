
using Cental.EntityLayer.Entities;

namespace Cental.DtoLayer.SubscriberDtos
{
    public class ResultSubscriberDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string Email { get; set; }
        public int? UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
