using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.UserModel;

namespace Domain.Models.Address
{
    public class AddressModel
    {


        [Key]
        public Guid AddressID { get; set; }
       

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public UserModels User { get; set; }

        [Required]
        public string StreetName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string Apartment { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }











    }
}
