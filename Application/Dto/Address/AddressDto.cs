using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Adress
{
    public class AddressDto
    {
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

   

        // Address history functionality
        // Example: You may want to track changes to this address over time

        // Localization support method
        // Example: Provide localized address components based on the user's preferred language

        // Security enhancements
        // Example: Implement encryption for sensitive address information

        // Integration with mapping services
        // Example: Integrate with mapping APIs for geocoding, reverse geocoding, etc.

        // Navigation properties

    }
}
