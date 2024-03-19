using Domain.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserModel
{
    public class UserModels
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
        public int PhoneNumber { get; set; }
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<AddressModel> Addresses { get; set; }
    }
}
