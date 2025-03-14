using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultFeatureComponent(IFeatureService _featureService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var features = _featureService.TGetAll();
            var featureDtos = _mapper.Map<List<ResultFeatureDto>>(features);
            var featureViewModel = new FeatureViewModel()
            {
                Features = featureDtos.Take(2).ToList(),
                FeaturesRight = featureDtos.Skip(2).Take(2).ToList()
            };
            return View(featureViewModel);
        }
    }
}
