using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Adress
{
    public class AddressDto
    {
        [Key]
        public Guid AddressId { get; set; }



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

        // Additional geographic information

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }





        // Address validation method
        public bool IsValidAddress()
        {
            // Implement your address validation logic here
            // Example: Check if all required fields are filled
            return
                   !string.IsNullOrWhiteSpace(StreetName) &&
                   !string.IsNullOrWhiteSpace(StreetNumber) &&
                   !string.IsNullOrWhiteSpace(ZipCode);
        }

        // Address formatting method
        public string FormatAddress()
        {
            // Implement address formatting logic here
            // Example: Concatenate address components into a formatted string
            return $"{StreetNumber} {StreetName}, {City}, {State} {ZipCode}, {Country}";
        }

        // Address history functionality
        // Example: You may want to track changes to this address over time

        // Localization support method
        // Example: Provide localized address components based on the user's preferred language

        // Security enhancements
        // Example: Implement encryption for sensitive address information

        // Integration with mapping services
        // Example: Integrate with mapping APIs for geocoding, reverse geocoding, etc.

        // Navigation properties
        public virtual List<Order.OrderDto>? Orders { get; set; }
        public virtual User.UserDto? User { get; set; }
        public virtual Warehouse.WarehouseDto? Warehouse { get; set; }
        public virtual Employee.EmployeeDto? Employee { get; set; }
    }
}
