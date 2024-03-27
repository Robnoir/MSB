using Domain.Models.Address;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.User
{
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<AddressModel> Addresses { get; set; } = new List<AddressModel>();
    }
}
