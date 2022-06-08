using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.ProductTypes;

public class ProductTypeDto : BaseDto
{
    public IEnumerable<PerfumeProductTypeDto> ProductTypes { get; set; } = new List<PerfumeProductTypeDto>();
}