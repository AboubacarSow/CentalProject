using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ContactDtos;
using Cental.DtoLayer.SocialPageDtos;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Mvc;


namespace Cental.WebUI.ViewComponents.Header
{
    public class TopBarComponent(IContactService _contactService,
        ICentalSocialPageService _socialService,
        IMapper _mapper) :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var pagesDto = _mapper.Map<List<ResultSocialPageDto>>(_socialService.TGetAll());
            var contactInfo = _mapper.Map<List<ResultContactDto>>(_contactService.TGetAll());

            var footerViewModel = new FooterViewModel()
            {
                Pages = pagesDto,
                Contacts = contactInfo
            };
            return View(footerViewModel);
        }
    }
}
