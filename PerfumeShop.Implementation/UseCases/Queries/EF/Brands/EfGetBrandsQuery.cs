using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.Application.UseCases.Queries.Brands;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Searches;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Brands
{
    public class EfGetBrandsQuery : IGetBrandsQuery
    {
        private readonly PerfumeContext _context;
        public EfGetBrandsQuery(PerfumeContext context)
        {
            _context = context;
        }
        public int Id => 1;

        public string Name => "Get Brands";

        public string Description => "Getting all brands from database using Entity Framework";

        public IEnumerable<BrandDto> Execute(BaseSearch request)
        {
            var query = _context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.BrandName.Contains(request.Keyword));
            }

            return query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.BrandName
            }).ToList();

        }
    }

}
