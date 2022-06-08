using PerfumeShop.Application.DTO;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.Queries.Perfumes;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Perfumes;

public class EfGetPerfumesQuery : EfUseCase, IGetPerfumesQuery
{
    public EfGetPerfumesQuery(PerfumeContext context) : base(context)
    {
    }

    public int Id => 9;
    public string Name => "Get All Perfumes";
    public string Description => "EntityFramework get all perfumes from database";

    public IEnumerable<PerfumeDto> Execute(BaseSearch request)
    {
        var perfumes = Context.Perfumes.AsQueryable();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            perfumes = perfumes.Where(x =>
                x.Name.Contains(request.Keyword) || x.Category.CategoryName.Contains(request.Keyword) ||
                x.Brand.BrandName.Contains(request.Keyword));
        }

        return perfumes.Select(x => new PerfumeDto()
        {
            Id = x.Id,
            BrandName = x.Brand.BrandName,
            Description = x.Description,
            CategoryName = x.Category.CategoryName,
            Name = x.Name,
            ProductTypes = x.PerfumeProductTypes.Select(ppt => ppt.ProductType.Type),
            Milliliters = x.PerfumeMilliliters.Select(pm => pm.Milliliter.Capacity)
            
        });
    }

    
}