using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Cental.WebUI.ViewComponents.Footer
{
    public class SubscriptionComponent(UserManager<AppUser> _userManager,ISubscriberService _subscriberService) :ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            var subscriptionViewModel = Task.Run(async () => await GetSubscriptionViewModelAsync()).Result;
            Debug.WriteLine($"IsSubscribed:{subscriptionViewModel.IsSubscribed}");
            Debug.WriteLine($"Subscribed Id:{subscriptionViewModel.SubscribedId}");
            return View(subscriptionViewModel);
        }
        private async Task<SubscriptionViewModel> GetSubscriptionViewModelAsync()
        {
            var subscriptionViewModel = new SubscriptionViewModel();

            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var subscriber = _subscriberService.TGetAll().FirstOrDefault(u => u.UserId == user.Id);

                if (subscriber is not null && subscriber.IsActive)
                {
                    subscriptionViewModel.SubscribedId= subscriber.Id;
                    subscriptionViewModel.IsSubscribed = true;
                }
                else
                {
                    subscriptionViewModel.IsSubscribed = false;
                }
            }

            return subscriptionViewModel;
        }

    }
}
