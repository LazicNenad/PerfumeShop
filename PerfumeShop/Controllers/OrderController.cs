using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.DTO.Orders;
using PerfumeShop.Application.DTO.PerfumeMilliliter;
using PerfumeShop.Application.UseCases.Commands.OrderCommands;
using PerfumeShop.Implementation;

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public OrderController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
