using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Dto.Driver;
using Application.Dto.Employee;

namespace Application.Dto.Car
{
    public class CarDto
    {
        [Required] public Guid CarId { get; set; }
        [Required] public Guid DriverId { get; set; }
        [Required] public double Volume { get; set; }
        [Required] public string Type { get; set; }
        [Required] public string Availability { get; set; }

        public class CarDetailDto : CarDto
        {
            public DriverDto Driver { get; set; }
        }

    }
}

