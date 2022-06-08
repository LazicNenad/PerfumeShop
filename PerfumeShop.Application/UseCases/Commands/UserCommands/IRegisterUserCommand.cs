using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Users;

namespace PerfumeShop.Application.UseCases.Commands.UserCommands
{
    public interface IRegisterUserCommand : ICommand<UserDto>
    {
    }
}
