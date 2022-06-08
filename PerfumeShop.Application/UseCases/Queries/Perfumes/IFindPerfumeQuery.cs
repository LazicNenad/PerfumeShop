using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Perfumes;

namespace PerfumeShop.Application.UseCases.Queries.Perfumes
{
    public interface IFindPerfumeQuery : IQuery<int, PerfumeDto>
    {
    }
}
