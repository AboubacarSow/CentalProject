using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.SocialPageDtos;

namespace Cental.WebUI.Models
{
    public class FooterViewModel
    {
        public List<ResultSocialPageDto> Pages { get; set; }
        public List<ResultContactDto> Contacts { get; set; }
    }
}
