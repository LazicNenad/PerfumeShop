using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Domain.Entities;

namespace PerfumeShop.Application.DTO.Perfumes;

public class PerfumeDto : BaseDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? BrandName { get; set; }
    public string? CategoryName { get; set; }
    public IEnumerable<string> ProductTypes { get; set; } = new List<string>();
    public IEnumerable<ushort> Milliliters { get; set; } = new List<ushort>();

}