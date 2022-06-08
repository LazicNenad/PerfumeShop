using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.DTO.Users;
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

        public IEnumerable<GetAllUsersDto> Execute(BaseSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(request.Keyword) || x.LastName.Contains(request.Keyword) || x.Username.Contains(request.Keyword));
            }

            return query.Select(x => new GetAllUsersDto
            {
                BirthDate = x.BirthDate,
                Email = x.Email,
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                Username = x.Username
            });
        }

        public int Id => 7;
        public string Name => "Get all users";
        public string Description => "Getting all users with EntityFramework";

        
    }
}
