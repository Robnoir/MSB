using Domain.Models.Address;

namespace Domain.Models.UserModel
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<AddressModel> Addresses { get; set; }
    }
}
