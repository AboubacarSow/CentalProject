using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    
    public class UserLayoutController(UserManager<AppUser> userManager) : Controller
    {
        private readonly UserManager<AppUser> _userManager = userManager;

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.FullName = String.Join(" ", user.FirstName, user.LastName);
            ViewBag.UserImage = user.ImageUrl;
            return View();
        }
    }
}
