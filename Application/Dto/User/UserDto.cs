using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.User
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public long PhoneNumber { get; set; } // Changed to long for international phone numbers

        [ForeignKey("PaymentMethodId")]
        public int PaymentMethodId { get; set; }

        // public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }

        // public Address Address { get; set; }
    }
}
