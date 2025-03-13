using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.BannerDtos;

using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultBannerComponent(IBannerService _bannerService,
        IMapper _mapper): ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var banners = _bannerService.TGetAll();
          

            
            return View(_mapper.Map<List<ResultBannerDto>>(banners));
        }
    }
}
