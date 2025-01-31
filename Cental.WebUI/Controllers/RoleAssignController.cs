using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cental.WebUI.Controllers
{
    public class RoleAssignController(UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            
            var usersDto=new List<ResultUserDto>();    
            foreach(var user in users)
            {
                var dto=new ResultUserDto();
                dto.Roles=await _userManager.GetRolesAsync(user);
                dto.Id=user.Id; 
                dto.FirstName=user.FirstName;   
                dto.LastName=user.LastName;
                dto.UserName = user.UserName;
                dto.Email = user.Email;
                usersDto.Add(dto);

            }
            return View(usersDto);
        }
        [HttpGet]   
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles= await _roleManager.Roles.ToListAsync();
            var userDto = new List<AssignRoleDto>();
            foreach (var role in roles)
            {
                var model = new AssignRoleDto();
                model.RoleName = role.Name;
                model.RoleId = role.Id;
                model.UserId = user.Id;
                model.RoleExist = userRoles.Contains(role.Name);    
                userDto.Add(model); 
            }
            return View(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> userDto)
        {
            var userId=userDto.Select(x => x.UserId).FirstOrDefault();
           var user= await _userManager.FindByIdAsync(userId.ToString());   
            foreach (var role in userDto) 
            {
                if (role.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
