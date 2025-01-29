using Cental.DtoLayer.Enums.Car_Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Infrastructure.Extensions
{
    public static class GetEnumValues
    {
        public static List<SelectListItem> GetValues <T>() 
        {
            var enumType = Enum.GetValues(typeof(T));
            var listItems = new List<SelectListItem>();
            foreach (var gas in enumType)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = gas.ToString(),
                    Value = gas.ToString()
                });
            }
            return listItems;
        }
    }
}
