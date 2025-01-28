using Cental.DtoLayer.BrandDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
