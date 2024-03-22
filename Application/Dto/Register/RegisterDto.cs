using Application.Dto.Adress;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Register
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public AddressDto Address { get; set; }
    }
}
