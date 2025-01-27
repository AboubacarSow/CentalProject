using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
	public class UIlLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
