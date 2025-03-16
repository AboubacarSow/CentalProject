

namespace Cental.EntityLayer.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public virtual AppUser? User { get; set; }
    }
}
