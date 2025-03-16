using Cental.EntityLayer.Entities;

namespace Cental.DtoLayer.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        public bool IsActive { get; set; } = true;
        public string Email { get; set; }
        public int? UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
