using FluentValidation;
using PerfumeShop.Application.UseCases.Commands.UserCommands;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;
using PerfumeShop.Implementation.Validations.UserValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Users;

namespace PerfumeShop.Implementation.UseCases.Commands.EF.Users
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly PerfumeContext _context;
        private readonly CreateUserValidation _validator;

        public EfRegisterUserCommand(PerfumeContext context, CreateUserValidation validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Register User Command";

        public string Description => "EntityFramework Register User";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                BirthDate = request.BirthDate,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = hashedPassword,
                Username = request.Username
            };

            _context.Users.Add(user);

            _context.SaveChanges();
        }
    }
}
