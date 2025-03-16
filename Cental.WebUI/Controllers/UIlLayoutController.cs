using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.SubscriberDtos;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cental.WebUI.Controllers
{
	[AllowAnonymous]
	public class UIlLayoutController(ISubscriberService _subscriberService,
		IMapper _mapper,
		UserManager<AppUser> _userManager) : Controller
	{
		public async Task<IActionResult> Index()
		{
			
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> Subscribe([FromBody] CreateSubscriberDto subscriberDto)
        {
			if (User.Identity is not null && User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				
				subscriberDto.UserId = user.Id;
				subscriberDto.User = user;
			}
			if (_subscriberService.TGetAll().Any(u => u.Email == subscriberDto.Email))
			{
				var subscriberU = _subscriberService.TGetAll().FirstOrDefault(s => s.Email == subscriberDto.Email);
				subscriberU.IsActive = true;
				_subscriberService.TUpdate(subscriberU);
                return Json(new { success = true, message = "Tebrikler! Tekrar Abone Oldunuz.🥳" });
            }
            var subscriber = _mapper.Map<Subscriber>(subscriberDto);
			_subscriberService.TCreate(subscriber);
			return Json(new { success = true, message = "Tebrikler! Abone Oldunuz.🥳" });
		}
		[HttpPost]
		public  IActionResult UnSubscribe([FromBody] UpdateSubscriberDto subscriberDto)
		{
			var subscriber =_subscriberService.TGetById(subscriberDto.Id);
			if(subscriber is not null)
			{
				subscriber.IsActive = false;
				_subscriberService.TUpdate(subscriber);

			   return Json(new { success = true, message = "Gitiğiniz için Üzgünüz 😪" });
			}
			else
			{
				return Json(new { success = false, message = "Abone Değilsiniz" });
			}
		}
	}
}
