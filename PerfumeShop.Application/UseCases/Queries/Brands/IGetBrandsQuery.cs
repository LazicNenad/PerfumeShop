using PerfumeShop.Application.UseCases.DTO.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Searches;

namespace PerfumeShop.Application.UseCases.Queries.Brands
{
    public interface IGetBrandsQuery : IQuery<PagedSearch, PagedResponse<BrandDto>>
    {
    }
}
