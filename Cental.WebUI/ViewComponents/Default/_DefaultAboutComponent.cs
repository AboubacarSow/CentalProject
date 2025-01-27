using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultAboutComponent : ViewComponent
    {
        private readonly IAboutService _aboutManager;
        private readonly IMapper _mapper;

        public _DefaultAboutComponent(IMapper mapper, IAboutService aboutManager)
        {
            _mapper = mapper;
            _aboutManager = aboutManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutManager.TGetAll();
            var model=_mapper.Map<List<ResultListAboutDto>>(values);
            return View (model); 
        }
    }
}
