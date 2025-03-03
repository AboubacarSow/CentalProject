using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
	//This controller belongs to our three types of user:Admin, Manager, User
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signManager,UserManager<AppUser> userManager)
		{
			_signManager = signManager;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			await _signManager.SignOutAsync();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index (UserLoginDto userDto, string? returnUrl)
		{
			var result = await _signManager.PasswordSignInAsync(userDto.UserName, userDto.Password, false, false);
			if(!result.Succeeded)
			{
				ModelState.AddModelError("", "kullanıcı Adı Veya Şifre Hatalıdır");
				return View(userDto);
			}	
			if(returnUrl!=null)
			{
				return Redirect(returnUrl);
			}	
			var user=await _userManager.FindByNameAsync(userDto.UserName);
			var userRoles = await _userManager.GetRolesAsync(user);
			
			foreach (var role in userRoles) 
			{
                var redirectAction = role switch
                {
                    "Admin" => RedirectToAction("Index", "AdminAbout"),
                    "Manager" => RedirectToAction("Index", "MySocial", new { area = "Manager" }),
                    "User" => RedirectToAction("Index", "MyProfile", new { area = "User" }),
                    _ => null
                };

				if(redirectAction != null)
					return redirectAction;	
               
			}
			return RedirectToAction("Index", "Default");
		}

		public async Task<IActionResult> Logout()
		{
			await _signManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
