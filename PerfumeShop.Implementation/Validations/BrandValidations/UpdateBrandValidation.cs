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
    public class UpdateBrandValidation : AbstractValidator<BrandDto>
    {
        public UpdateBrandValidation(PerfumeContext context)
        {
            RuleFor(x => x)
                .Must(x => !context.Brands.Any(y => y.BrandName == x.Name && y.Id != x.Id))
                .WithMessage("Brand with this value already exist in database");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Brand name field is required")
                .MinimumLength(3)
                .WithMessage("Brand name minimum lenght is 3");

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required for updating");
        }

    }
}
