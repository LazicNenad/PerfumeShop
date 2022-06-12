using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.Application.DTO.Searches;

namespace PerfumeShop.Application.UseCases.Queries.Milliliters
{
    public interface IGetMillilitersQuery : IQuery<PagedSearch, PagedResponse<MilliliterDto>>
    {
    }
}
