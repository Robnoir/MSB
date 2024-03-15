using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Car
{
    public class CarDto
    {
        [Key] // Specifies CarID as the primary key
        public int CarID { get; set; }

        public double Volume { get; set; }
        public string Type { get; set; }
        public string Availability { get; set; }

        [ForeignKey("DriverID")] // Specifies DriverID as the foreign key
        public int DriverID { get; set; }

        //public Driver Driver { get; set; }
    }
}

