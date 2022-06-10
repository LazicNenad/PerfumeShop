using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Perfumes;

namespace PerfumeShop.Application.UseCases.Commands.PerfumeCommands
{
    public interface ICreatePerfumeCommand : ICommand<CreateUpdatePerfumeDto>
    {
    }
}
