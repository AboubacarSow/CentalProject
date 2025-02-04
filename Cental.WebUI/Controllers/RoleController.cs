using Cental.DtoLayer.UserRole;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> _roleManager) : Controller
    {
        public IActionResult Index()
        {
            var roles=_roleManager.Roles.ToList();  
            var rolesDto=roles.Adapt<List<ResultRoleDto>>();

            return View(rolesDto);
        }
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(ResultRoleDto roleDto)
        {
            var role = roleDto.Adapt<AppRole>();
            var result = await _roleManager.CreateAsync(role);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description); 
                }
                return  View(roleDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var role =await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");   
        } 
        public async Task<IActionResult> Update(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var roleDto=role.Adapt<UpdateRoleDto>();
            return View(roleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleDto roleDto)
        {
            var role=roleDto.Adapt<AppRole>();    
            var result=await _roleManager.UpdateAsync(role);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(roleDto);
            }
            return RedirectToAction("Index");

        }

    }
}
