using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.AdminLayout
{
    public class _AdminLayoutSideBarComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user=await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.FullName = String.Join(" ", user.FirstName, user.LastName);
            ViewBag.UserImage=user.ImagerUrl;
            return View();  
        }
    }
}
