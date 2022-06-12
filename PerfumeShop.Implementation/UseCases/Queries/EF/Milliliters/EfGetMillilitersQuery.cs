using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.Application.UseCases.Queries.Milliliters;
using PerfumeShop.DataAccess;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Milliliters
{
    public class EfGetMillilitersQuery : EfUseCase, IGetMillilitersQuery
    {
        public EfGetMillilitersQuery(PerfumeContext context) 
            : base(context) 
        {
            
        }

        public PagedResponse<MilliliterDto> Execute(PagedSearch request)
        {
            var response = new PagedResponse<MilliliterDto>();

            var milliliters = Context.Milliliters.AsQueryable();

            var millilitersCount = Context.Milliliters.Count();

            if (request.PerPage == null || request.PerPage < 1)
            {
                request.PerPage = 15;
            }

            if (request.Page == null || request.Page < 1)
            {
                request.PerPage = 1;
            }

            var toSkip = (request.Page.Value - 1) * request.PerPage.Value;

            response.TotalCount = millilitersCount;

            response.Data = milliliters.Skip(toSkip).Take((int)request.PerPage).Select(x => new MilliliterDto()
            {
                Id = x.Id,
                Capacity = x.Capacity
            });

            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage.Value;

            return response;
        }

        public int Id => 14;
        public string Name => "Get Milliliters";
        public string Description => "EntityFramework Get Milliliters";
    }
}
