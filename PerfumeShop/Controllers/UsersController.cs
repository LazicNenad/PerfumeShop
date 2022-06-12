using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.API.Extensions;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.DTO.Users;
using PerfumeShop.Application.UseCases.Commands.UserCommands;
using PerfumeShop.Application.UseCases.Queries.Users;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IGetUsersQuery query, [FromQuery] PagedSearch dataBaseSearch)
        {
            return Ok(_handler.HandleQuery(query, dataBaseSearch));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserDto dto, [FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
