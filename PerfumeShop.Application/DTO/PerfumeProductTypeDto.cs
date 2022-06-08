using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.ProductTypes;
using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO;

public class PerfumeProductTypeDto : BaseDto
{

    public string? Perfume { get; set; } 
    public string? ProductTypes { get; set; } 
}