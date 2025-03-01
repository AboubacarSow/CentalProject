using Cental.DtoLayer.CarDtos;
using FluentValidation;


namespace Cental.BusinessLayer.Validators.CarDtosValidation
{
    public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
    {
        public CreateCarDtoValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Araba Modeli boş Bırakılamaz");
            RuleFor(x => x.Transmission).NotEmpty().WithMessage("Vites Türü boş Bırakılamaz");
            RuleFor(x => x.GasType).NotEmpty().WithMessage("Yakıt Türü boş Bırakılamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat boş Bırakılamaz");
            RuleFor(x => x.Year).NotEmpty().WithMessage("Yıl boş Bırakılamaz");
            RuleFor(x => x.Kilometer).NotEmpty().WithMessage("Km değeri boş Bırakılamaz");
            RuleFor(x => x.GearType).NotEmpty().WithMessage("Vites değeri boş Bırakılamaz");
            RuleFor(x => x.SeatCount).NotEmpty().WithMessage("Koltuk Sayısı boş Bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Yükleyin");
 
        }
    }
}
