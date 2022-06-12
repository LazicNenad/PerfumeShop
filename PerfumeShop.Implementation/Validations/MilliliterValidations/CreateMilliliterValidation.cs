using FluentValidation;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.Validations.MilliliterValidations;

public class CreateMilliliterValidation : AbstractValidator<MilliliterDto>
{
    public CreateMilliliterValidation(PerfumeContext context)
    {
        RuleFor(x => x.Capacity).Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Capacity is required field")
            .GreaterThan((ushort)0).WithMessage("Capacity must be greater than 0")
            .Must(c => !context.Milliliters.Any(m => m.Capacity == c))
                .WithMessage("Milliliter with value of {PropertyValue} already exists in database");
    }
}