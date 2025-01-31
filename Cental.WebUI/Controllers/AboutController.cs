using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.AboutDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutManager;

        public AboutController(IAboutService aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            var model = _aboutManager.TGetAll().Select(about => new ResultAboutDto
            {
                AboutId = about.AboutId,
                Vision = about.Vision,
                Mission = about.Mission,
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateAboutDto model)
        {
            _aboutManager.TCreate(new About
            {
                Vision = model.Vision,
                Mission = model.Mission,
                Description = model.Description,
                Description1 = model.Description1,
                StartYear = model.StartYear,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                ImageUrl1 = model.ImageUrl1,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                JobTitle = model.JobTitle,
                ProfileImage = model.ProfileImage
            });
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _aboutManager.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _aboutManager.TGetById(id);

            return View(new UpdateAboutDto
            {
                AboutId = model.AboutId,
                Vision = model.Vision,
                Mission = model.Mission,
                Description = model.Description,
                Description1 = model.Description1,
                StartYear = model.StartYear,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                ImageUrl1 = model.ImageUrl1,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                JobTitle = model.JobTitle,
                ProfileImage = model.ProfileImage
            });    
        }
        [HttpPost]
        public IActionResult Update(UpdateAboutDto model)
        {
            _aboutManager.TUpdate( new About
            {
                AboutId = model.AboutId,
                Vision = model.Vision,
                Mission = model.Mission,
                Description = model.Description,
                Description1 = model.Description1,
                StartYear = model.StartYear,
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                ImageUrl1 = model.ImageUrl1,
                Item1 = model.Item1,
                Item2 = model.Item2,
                Item3 = model.Item3,
                JobTitle = model.JobTitle,
                ProfileImage = model.ProfileImage
            });
            return RedirectToAction("Index");
        }
    }
}
