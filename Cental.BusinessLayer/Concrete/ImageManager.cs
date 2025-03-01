using Cental.BusinessLayer.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Http;


namespace Cental.BusinessLayer.Concrete
{
	public class ImageManager : IImageService
	{
		public async Task<string> SaveImageAsync(IFormFile formfile)
		{
			var currentDirectory=Directory.GetCurrentDirectory();
			var extension=Path.GetExtension(formfile.FileName).ToLowerInvariant();	
			if(extension !=".jpg" &&  extension !=".jpeg" && extension != ".png" && extension != ".PNG")
			{
				//Fluent Validation
				throw new ValidationException("Dosya Formatı Resim Olmalıdır");
			}
			var imageName=Guid.NewGuid() + extension;



			var imagePath = Path.Combine(currentDirectory,"wwwroot/images", imageName);
			
			var stream=new FileStream(imagePath, FileMode.Create);	
			await formfile.CopyToAsync(stream);
			return "/images/" + imageName;
		}
	}
}
