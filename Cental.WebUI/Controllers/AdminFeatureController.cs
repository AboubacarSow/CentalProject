using AutoMapper;
using Azure.Core;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.FeatureDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminFeatureController(IFeatureService _featureService,
        IMapper _mapper): Controller
    {
        public IActionResult Index()
        {
            var features = _featureService.TGetAll();
            var featureDtos = _mapper.Map<List<ResultFeatureDto>>(features);
            return View(featureDtos);
        }
        public IActionResult Delete([FromRoute] int id)
        {
            _featureService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateFeatureDto featureDto)
        {
            if (!ModelState.IsValid)
                return View(featureDto);
            var feature = _mapper.Map<Feature>(featureDto);
            _featureService.TCreate(feature);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update([FromRoute] int id)
        {
            var feature = _featureService.TGetById(id);
            var featureDto = _mapper.Map<UpdateFeatureDto>(feature);
            return View(featureDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateFeatureDto featureDto)
        {
            if (!ModelState.IsValid)
                return View(featureDto);
            var feature = _mapper.Map<Feature>(featureDto);
            _featureService.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
