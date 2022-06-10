using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;

namespace PerfumeShop.Application.UseCases.Queries.Perfumes;

public interface IGetPerfumesQuery : IQuery<PagedSearch, PagedResponse<PerfumeDto>>
{
    
}