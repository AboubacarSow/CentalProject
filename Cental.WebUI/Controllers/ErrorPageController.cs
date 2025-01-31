using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult NotFoundedPage()
        {
            return View();      
        }
    }
}
