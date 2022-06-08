using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.Application.UseCases.Queries.Brands;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Brands;

public class EfFindBrandQuery : EfUseCase, IFindBrandQuery
{
    public EfFindBrandQuery(PerfumeContext context) : base(context)
    {
    }
    
    public int Id => 8;
    public string Name => "Find Brand by ID";
    public string Description => "EntityFramework Finding brand by ID";
    public BrandDto Execute(int request)
    {
        var brand = Context.Brands.Find(request);

        if (brand == null)
        {
            throw new NotFountException($"Brand with {request} id is not found in our system");
        }

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.BrandName
        };
    }
}