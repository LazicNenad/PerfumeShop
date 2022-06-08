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
    public class DeleteBrandValidation : AbstractValidator<int>
    {
        public DeleteBrandValidation(PerfumeContext context)
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Brand Id is required parameter in order to delete entity.")
                .Must(x => context.Brands.Any(b => b.Id == x))
                .WithMessage("Brand with id {PropertyValue} doesnt exist in database.");
        }
    }
}
