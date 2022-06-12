using FluentValidation;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.Validations.MilliliterValidations;

public class UpdateMilliliterValidation : AbstractValidator<MilliliterDto>
{
    public UpdateMilliliterValidation(PerfumeContext context)
    {
        Include(x => new CreateMilliliterValidation(context));
        RuleFor(x => x)
            .Cascade(CascadeMode.Stop)
            .Must(x => !context.Milliliters.Any(y => y.Capacity == x.Capacity && y.Id != x.Id))
            .WithMessage("Capacity with this value already exists in our database");
    }
}