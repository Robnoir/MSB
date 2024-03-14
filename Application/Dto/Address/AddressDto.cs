using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Adress
{
    public class AddressDto
    {
        [Key] // Specifies AddressID as the primary key
        public int AddressID { get; set; }

        public string Name { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Apartment { get; set; }
        public string ZipCode { get; set; }
        public string Floor { get; set; }
        public string DeliveryNotes { get; set; }
    }
}