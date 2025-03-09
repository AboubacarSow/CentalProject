using AutoMapper;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Manager
{
    public class _DefaultManagerComponent(UserManager<AppUser> _userManager,IMapper _mapper) : ViewComponent
    {
        public  async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("Manager");
            var userDtos = _mapper.Map<List<ResultUserDto>>(users);
            return View(userDtos);
        }
    }
}
