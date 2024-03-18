using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Address
{
    public class AddressModel
    {
        [Key]
        public Guid AddressId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public string Country { get; set; } = string.Empty;
    }
}
