using FluentValidation;
using PerfumeShop.Application.DTO.Milliliters;

namespace PerfumeShop.Implementation.Validations.MilliliterValidations;

public class RemoveMilliliterValidation : AbstractValidator<int>
{
    public RemoveMilliliterValidation()
    {
        RuleFor(x => x).NotEmpty().WithMessage("Capacity is required field in order to delete it");
    }
}