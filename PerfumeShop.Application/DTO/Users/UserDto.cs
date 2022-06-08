using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Application.DTO.Users
{
    public class UserDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Username { get; set; }
    }
}
