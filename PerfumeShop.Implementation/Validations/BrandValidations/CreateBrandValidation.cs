using FluentValidation;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.Validations.BrandValidations
{
    public class CreateBrandValidation : AbstractValidator<BrandDto>
    {
        public CreateBrandValidation(PerfumeContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Brand name is required parameter")
                .MinimumLength(3)
                .WithMessage("Brand name minimum length is 3 characters")
                .Must(p => !context.Brands.Any(pn => pn.BrandName == p))
                .WithMessage("Brand {PropertyValue} already exist in database");
        }
    }
}
