using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
	[AllowAnonymous]
	public class UIlLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
