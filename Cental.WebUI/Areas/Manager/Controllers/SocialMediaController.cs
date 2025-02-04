using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.UserSocialDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    public class SocialMediaController(UserManager<AppUser> _userManager,
        IMapper _mapper, IUserSocialService _userSocialManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);
            var userSocail = _userSocialManager.GetByUserId(user.Id);
            var socialDto = _mapper.Map<List<ResultUserSocialDto>>(userSocail);
            return View(socialDto);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserSocialDto socialDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            socialDto.UserId = user.Id;
            var social= _mapper.Map<MSocialMedia>(socialDto);
            _userSocialManager.TCreate(social);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _userSocialManager.TDelete(id);
            return RedirectToAction("Index");
        }
    }
}
