using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.Application.UseCases.Queries.Brands;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;

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

        public PagedResponse<BrandDto> Execute(PagedSearch request)
        {
            var response = new PagedResponse<BrandDto>();

            var query = _context.Brands.AsQueryable();

            var totalBrandsCount = _context.Brands.Count();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.BrandName.Contains(request.Keyword));
            }

            if (request.PerPage == null || request.PerPage < 1)
            {
                request.PerPage = 15;
            }

            if (request.Page == null || request.Page < 1)
            {
                request.PerPage = 1;
            }

            var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

            response.TotalCount = totalBrandsCount;

            response.Data = query.Skip(toSkip).Take((int)request.PerPage).Select(x => new BrandDto()
            {
                Id = x.Id,
                Name = x.BrandName
            });



            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage.Value;


            return response;

        }
    }

}
