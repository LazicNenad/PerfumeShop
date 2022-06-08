using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.API.Extensions;
using PerfumeShop.Application.DTO.Searches;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.DTO.Brands;
using PerfumeShop.Application.UseCases.Queries.Brands;
using PerfumeShop.Domain;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] BaseSearch search,
            [FromServices] IGetBrandsQuery query,
            [FromServices] IApplicationUser user)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindBrandQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        [HttpPost]
        public IActionResult Post(
            [FromBody] BrandDto dto,
            [FromServices] ICreateBrand command
        )
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto value, [FromServices] IUpdateBrand command)
        {
            var brand = new BrandDto
            {
                Id = id,
                Name = value.Name
            };

            _handler.HandleCommand(command, brand);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrand command)
        {

            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}