using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.PerfumeMilliliter;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.Validations
{
    public class PerfumeMilliliterValidation : AbstractValidator<PerfumeMilliliterDto>
    {
        public PerfumeMilliliterValidation(PerfumeContext context)
        {
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required parameter")
                .GreaterThan(0).WithMessage("Quantity has to be greater than 0");

            RuleFor(x => x.MilliliterId)
                .NotEmpty().WithMessage("MilliliterId is required parameter")
                .Must(x => context.Milliliters.Any(m => m.Id == x))
                .WithMessage("MilliliterId {PropertyValue} doesn't exist in database");

            RuleFor(x => x.PerfumeId)
                .NotEmpty().WithMessage("PerfumeId is required parameter")
                .Must(x => context.Perfumes.Any(p => p.Id == x))
                .WithMessage("PerfumeId {PropertyValue} doesn't exist in our database");
        }
    }
}
