using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Manager
{
    public class _DefaultManagerComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("Manager");
            var userDtos = users.Adapt<List<ResultUserDto>>();
            return View(userDtos);
        }
    }
}
