using PerfumeShop.Application.DTO;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.Queries;
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

    public PagedResponse<PerfumeDto> Execute(PagedSearch request)
    {
        var perfumes = Context.Perfumes.AsQueryable();

        var totalCountPerfumes = Context.Perfumes.Count();

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            perfumes = perfumes.Where(x =>
                x.Name.Contains(request.Keyword) || x.Category.CategoryName.Contains(request.Keyword) ||
                x.Brand.BrandName.Contains(request.Keyword));
        }

        if (request.PerPage == null || request.PerPage < 1)
        {
            request.PerPage = 15;
        }

        if (request.Page == null || request.Page < 1)
        {
            request.PerPage = 1;
        }

        var response = new PagedResponse<PerfumeDto>();

        var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

        response.TotalCount = totalCountPerfumes;
        response.Data = perfumes.Skip(toSkip).Take((int)request.PerPage).Select(x => new PerfumeDto()
        {
            Id = x.Id,
            BrandName = x.Brand.BrandName,
            Description = x.Description,
            CategoryName = x.Category.CategoryName,
            Name = x.Name,
            ProductTypes = x.PerfumeProductTypes.Select(ppt => ppt.ProductType.Type),
            Milliliters = x.PerfumeMilliliters.Select(pm => pm.Milliliter.Capacity),
            UnitPrices = x.PerfumeMilliliters.Select(y => new PerfumeUnitPriceDto()
            {
                UnitPrice = y.UnitPrice,
                MilliliterCapacity = y.Milliliter.Capacity
            })
        }).ToList();
        response.CurrentPage = request.Page.Value;
        response.ItemsPerPage = request.PerPage.Value;

        return response;
    }

    
}