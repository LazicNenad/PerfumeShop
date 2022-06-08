using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.DTO.Perfumes;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.Commands.PerfumeCommands;
using PerfumeShop.Application.UseCases.Queries.Perfumes;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PerfumesController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        // GET: api/<PerfumesController>
        public PerfumesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetPerfumesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IFindPerfumeQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        [HttpPost]
        public IActionResult Post(CreatePerfumeDto dto, [FromServices] ICreatePerfumeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemovePerfumeCommand command)
        {
            _handler.HandleCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
