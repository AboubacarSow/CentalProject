using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultServiceComponent(IServiceService _manager, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var services = _manager.TGetAll();
            var serviceDtos = _mapper.Map<List<ResultServiceDto>>(services);
            return View(serviceDtos);
        }
    }
}
