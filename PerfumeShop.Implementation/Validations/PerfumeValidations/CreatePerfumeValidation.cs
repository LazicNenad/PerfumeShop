using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.Validations.PerfumeValidations
{
    public class CreatePerfumeValidation : AbstractValidator<CreatePerfumeDto>
    {
        public CreatePerfumeValidation(PerfumeContext context)
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name field is required")
                .MinimumLength(3).WithMessage("Name must have at least 3 characters");

            RuleFor(x => x.BrandId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BrandId field is required")
                .Must(x => context.Brands.Any(b => b.Id == x))
                    .WithMessage("Brand {PropertyValue} doesn't exist in database");

            RuleFor(x => x.CategoryId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BrandId field is required")
                .Must(x => context.Categories.Any(c => c.Id == x))
                .WithMessage("Category {PropertyValue} doesn't exist in database");

            RuleFor(x => x.ProductTypeIds).Cascade(CascadeMode.Stop)
                .Must(x => x.Any()).WithMessage("ProductTypeIds must have at least 1 element")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed");

            RuleFor(x => x.MilliliterIds).Cascade(CascadeMode.Stop)
                .Must(x => x.Any()).WithMessage("MilliliterIds must have at least 1 element")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed");

            RuleForEach(x => x.ProductTypeIds).Cascade(CascadeMode.Stop)
                .Must(x => context.ProductTypes.Any(pt => pt.Id == x))
                .WithMessage("ProductTypeId {PropertyValue} doesn't exist in database");

            RuleForEach(x => x.MilliliterIds).Cascade(CascadeMode.Stop)
                .Must(x => context.Milliliters.Any(m => m.Id == x))
                .WithMessage("MilliliterId {PropertyValue} doesn't exist in database");


        }
    }
}
