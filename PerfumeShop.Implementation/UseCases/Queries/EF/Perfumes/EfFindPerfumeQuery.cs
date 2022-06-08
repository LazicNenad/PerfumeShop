using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Queries.Perfumes;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Perfumes
{
    public class EfFindPerfumeQuery : EfUseCase, IFindPerfumeQuery
    {
        public EfFindPerfumeQuery(PerfumeContext context) : base(context)
        {
        }

        public int Id => 10;
        public string Name => "Find Perfume by Id";
        public string Description => "EntityFramework find perfume by Id";

        public PerfumeDto Execute(int request)
        {
            var perfume = Context.Perfumes.Find(request);

            if (perfume == null)
            {
                throw new NotFountException($"Perfume with {request} id not found in our system");
            }

            return new PerfumeDto()
            {
                Name = perfume.Name,
                BrandName = perfume.Brand.BrandName,
                ProductTypes = perfume.PerfumeProductTypes.Select(x => x.ProductType.Type),
                Milliliters = perfume.PerfumeMilliliters.Select(y => y.Milliliter.Capacity),
                Id = perfume.Id,
                CategoryName = perfume.Category.CategoryName,
                Description = perfume.Description,
            };
        }
    }


}
