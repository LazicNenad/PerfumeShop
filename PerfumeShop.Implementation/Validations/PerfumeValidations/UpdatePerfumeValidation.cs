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
    public class UpdatePerfumeValidation : AbstractValidator<CreateUpdatePerfumeDto>
    {
        public UpdatePerfumeValidation(PerfumeContext context)
        {
            RuleFor(x => x)
                .Must(x => !context.Perfumes.Any(y => y.Name == x.Name && y.Id != x.Id))
                .WithMessage($"Perfume with current Name already exist in database");
            Include(x => new CreatePerfumeValidation(context));
        }
    }
}
