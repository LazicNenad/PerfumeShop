using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PerfumeShop.Application.DTO.Orders;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.Validations.OrderValidations
{
    public class OrderValidation : AbstractValidator<OrderDto>
    {
        public OrderValidation(PerfumeContext context)
        {
            RuleFor(x => x.UserId)
                .Must(o => context.Users.Any(u => u.Id == o))
                .WithMessage("User with {PropertyValue} doesn't exist in our database");

            RuleFor(x => x.PerfumeMilliliterIds)
                .NotEmpty().WithMessage("PerfumeMilliliterIds should not be empty, it should contain array of objects that has properties: 'perfumeId', 'milliliterId', 'quantity', 'unitPrice'");

            RuleForEach(x => x.PerfumeMilliliterIds)
                .NotEmpty()
                .SetValidator(new PerfumeMilliliterValidation(context));
        }
    }
}
