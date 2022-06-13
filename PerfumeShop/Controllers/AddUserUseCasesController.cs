using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.Exceptions;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Domain.Entities;

namespace PerfumeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddUserUseCasesController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private readonly PerfumeContext _context;

        public AddUserUseCasesController(IApplicationUser user, PerfumeContext context)
        {
            _user = user;
            _context = context;
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                var user = _context.Users.Find(_user.Id);

                if (user == null)
                {
                    throw new NotFountException($"User not found");
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                var useCases = new List<int>();

                for (var i = 1; i < 18; i++)
                {
                    _context.UserUseCases.Add(new UserUseCase()
                    {
                        User = user,
                        UseCaseId = i
                    });
                }

                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }
    }
}
