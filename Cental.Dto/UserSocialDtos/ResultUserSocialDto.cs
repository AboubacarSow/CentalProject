using Cental.DtoLayer.UserDtos;

namespace Cental.DtoLayer.UserSocialDtos
{
    public class ResultUserSocialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public virtual ResultUserDto ResultUserDto { get; set; }
    }
}
