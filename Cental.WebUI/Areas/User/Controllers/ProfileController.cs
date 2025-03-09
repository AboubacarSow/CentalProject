using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cental.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProfileController(UserManager<AppUser> _userManager,
        IImageService _imageService,
        IMapper _mapper) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userDto = user.Adapt<ResultProfileDto>();
            return View(userDto);
        } 

        public async Task<IActionResult> Update()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userDto = user.Adapt<ProfileEditDto>();
            return View(userDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProfileEditDto userDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var checkPassword = await _userManager.CheckPasswordAsync(user, userDto.CurrentPassword);
            if (checkPassword)
            {
                if (userDto.ImageFile != null)
                {
                    if (userDto.ImageFile != null)
                    {
                        try
                        {
                            userDto.ImageUrl = await _imageService.SaveImageAsync(userDto.ImageFile);
                            user.ImageUrl = userDto.ImageUrl;

                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", ex.Message);
                            return View(userDto);
                        }
                    }
                    user.FirstName = userDto.FirstName;
                    user.LastName = userDto.LastName;
                    user.Email =userDto.Email;
                    user.PhoneNumber = userDto.PhoneNumber;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(userDto);
                }
            }
            ModelState.AddModelError("", "Girdiğiniz Şifre Hatalıdır. Güncelleme Yapılamadı");
            return View(userDto);
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userDto)
        {
            var user = _mapper.Map<AppUser>(userDto);

            if (!ModelState.IsValid)
            {
                return View(userDto);
            }
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);

                }
                return View(userDto);
            }
            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction("Index", "Login");
        }
    }
}
