using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.DTO.Users;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.Application.UseCases.Queries.Users;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain.Entities;

namespace PerfumeShop.Implementation.UseCases.Queries.EF.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(PerfumeContext context) : base(context)
        {
        }

        public PagedResponse<UserDto> Execute(PagedSearch request)
        {
            var response = new PagedResponse<UserDto>();

            var query = Context.Users.AsQueryable();

            var usersTotalCount = Context.Users.Count();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(request.Keyword) || x.LastName.Contains(request.Keyword) || x.Username.Contains(request.Keyword));
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

            response.TotalCount = usersTotalCount;
            response.Data = query.Skip(toSkip).Take((int)request.PerPage).Select(x => new UserDto()
            {
                BirthDate = x.BirthDate,
                Email = x.Email,
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Username = x.Username

            }).ToList();
            response.CurrentPage = request.Page.Value;
            response.ItemsPerPage = request.PerPage.Value;

            return response;
        }

        public int Id => 7;
        public string Name => "Get all users";
        public string Description => "Getting all users with EntityFramework";

        
    }
}
