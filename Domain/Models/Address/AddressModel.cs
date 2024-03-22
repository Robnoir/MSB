using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.User;

namespace Domain.Models.Address
{
    public class AddressModel
    {

        [Key]
        public Guid AddressId { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;





    }
}
