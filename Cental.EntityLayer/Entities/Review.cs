

namespace Cental.EntityLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating {  get; set; }    
        public int CarId {  get; set; }
        public virtual Car Car { get; set; }    
    }
}
