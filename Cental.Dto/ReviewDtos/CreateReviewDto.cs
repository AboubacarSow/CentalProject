using Cental.DtoLayer.CarDtos;

namespace Cental.DtoLayer.ReviewDtos
{
    public class CreateReviewDto
    {
        public int Rating { get; set; }
        public int CarId { get; set; }
        public virtual ResultListCarDto? ResultCarDto { get; set; }
    }
}
