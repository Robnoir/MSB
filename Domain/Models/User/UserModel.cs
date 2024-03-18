using Domain.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.UserModel
{
    public class UserModel
    {
        [Key]
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<AddressModel> Addresses { get; set; }
    }
}
