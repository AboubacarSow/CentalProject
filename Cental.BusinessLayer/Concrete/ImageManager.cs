using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
	public class ImageManager : IImageService
	{
		public async Task<string> SaveImageAsync(IFormFile formfile)
		{
			var currentDirectory=Directory.GetCurrentDirectory();
			var extension=Path.GetExtension(currentDirectory).ToLowerInvariant();	
			if(extension !=".jpg" &&  extension !="jpeg" && extension != "png")
			{
				throw new Exception("Dosya Formatı Resim Olmalıdır");
			}
			var imageName=Guid.NewGuid().ToString() + extension;
			var imagePath = Path.Combine(currentDirectory, imageName);
			var stream=new FileStream(imagePath, FileMode.Create);	
			await formfile.CopyToAsync(stream);
			return "/images/" + imageName;
		}
	}
}
