using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.DTO.Milliliters;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.Commands.MilliliterCommands;
using PerfumeShop.Application.UseCases.Queries.Milliliters;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MillilitersController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        // GET: api/<MillilitersController>
        public MillilitersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] PagedSearch search, [FromServices] IGetMillilitersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        // POST api/<MillilitersController>
        [HttpPost]
        public IActionResult Post([FromBody] MilliliterDto dto, [FromServices] ICreateMilliliterCommand command)
        {
            _handler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MillilitersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MilliliterDto dto, [FromServices] IUpdateMilliliterCommand command)
        {
            dto.Id = id;

            _handler.HandleCommand(command, dto);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<MillilitersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveMilliliterCommand command)
        {
            _handler.HandleCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
