using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class About : Controller
    {
        private readonly IAboutService _aboutManager;

        public About(IAboutService aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            return View(_aboutManager.TGetAll());
        }
    }
}
