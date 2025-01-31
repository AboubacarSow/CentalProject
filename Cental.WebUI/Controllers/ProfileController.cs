using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
					try
					{
						_userDto.ImageUrl = await _imageManager.SaveImageAsync(_userDto.ImageFile);

					}
					catch(Exception ex)
					{ 
						ModelState.AddModelError("",ex.Message);
						return View(_userDto);
					}
				}
				user.FirstName=_userDto.FirstName;
				user.LastName=_userDto.LastName;
				user.Email=_userDto.Email;
				user.PhoneNumber=_userDto.PhoneNumber;
				user.ImagerUrl = _userDto.ImageUrl;

				var result = await _userManager.UpdateAsync(user);
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
