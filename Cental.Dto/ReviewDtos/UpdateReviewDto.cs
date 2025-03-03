using Cental.DtoLayer.CarDtos;

namespace Cental.DtoLayer.ReviewDtos
{
    public class UpdateReviewDto 
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int CarId { get; set; }
        public virtual ResultListCarDto? ResultCarDto { get; set; }
    }
}
