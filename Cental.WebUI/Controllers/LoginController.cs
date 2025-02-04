using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signManager;

		public LoginController(SignInManager<AppUser> signManager)
		{
			_signManager = signManager;
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
			return RedirectToAction("Index","About");
		}

		public async Task<IActionResult> Logout()
		{
			await _signManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
