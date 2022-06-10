using FluentValidation;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Users;

namespace PerfumeShop.Implementation.Validations.UserValidations
{
    public class CreateUserValidation : AbstractValidator<UserDto>
    {
        public CreateUserValidation(PerfumeContext context)
        {

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(2)
                .WithMessage("FirstName must contain at least 2 characters");

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .MinimumLength(2)
                .WithMessage("LastName must contain at least 2 characters");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(10)
                .WithMessage("Email minimum length is 10 characters")
                .Must(x => !context.Users.Any(m => m.Email == x))
                .WithMessage("Email {PropertyValue} already exist in Database");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(5)
                .WithMessage("Username minimum length is 5")
                .Must(x => !context.Users.Any(u => u.Username == x))
                .WithMessage("Username {PropertyValue} already exist in database");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("First name is required.")
                .MinimumLength(8)
                .WithMessage("Password must contain at least 8 characters");
        }
    }
}
