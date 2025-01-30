using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
	public class ProfileController(UserManager<AppUser> _userManager,IImageService _imageManager) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var user=await _userManager.FindByNameAsync(User.Identity.Name);
			var userDto = user.Adapt<ProfileEditDto>();
			return View(userDto);
		}
		[HttpPost]
		public async Task<IActionResult> Index(ProfileEditDto _userDto)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			var checkPassword = await _userManager.CheckPasswordAsync(user, _userDto.CurrentPassword);
			if (checkPassword)
			{

				if(_userDto.ImageFile != null)
				{
					_userDto.ImageUrl = await _imageManager.SaveImageAsync(_userDto.ImageFile);
				}

				var editedUser= _userDto.Adapt<AppUser>();
				var result = await _userManager.UpdateAsync(editedUser);
				if (result.Succeeded)
				{
					return RedirectToAction("Index","About");
				}
				foreach(var error in  result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View(_userDto);
			}
			ModelState.AddModelError("", "Girdiğiniz Şifre Hatalıdır. Güncelleme Yapılamadı");
			return View(_userDto);
		}
	}
}
