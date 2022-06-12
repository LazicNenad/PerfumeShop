using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.DTO.Users;

namespace PerfumeShop.Application.UseCases.Queries.Users
{
    public interface IGetUsersQuery : IQuery<PagedSearch, PagedResponse<UserDto>>
    {
    }
}
