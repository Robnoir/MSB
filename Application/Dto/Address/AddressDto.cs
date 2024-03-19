using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Adress
{
    public class AddressDto
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Apartment { get; set; }
        public string ZipCode { get; set; }
        public string Floor { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}