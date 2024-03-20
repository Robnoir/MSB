using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Employee;

namespace Domain.Models.Driver
{
    public class DriverModel
	{
        [Key]
        public Guid DriverId { get; set; }
        public Guid EmployeeId { get; set; }
        //Public Guid CarId { get; set; }

        public EmployeeModel Employee { get; set; }
        //public CarModel Car { get; set; }
    }
}

