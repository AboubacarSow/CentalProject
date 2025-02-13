using Cental.DtoLayer.BrandDtos;
using FluentValidation;

namespace Cental.BusinessLayer.Validators.BrandDtosValidation
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x => x.BrandName)
                 .NotEmpty().WithMessage("Marka İsmi Boş Bırakılamaz")
                 .MinimumLength(3).WithMessage("Marka İsmi en az 3 karakter Olmalıdır.");
        }
    }
}
