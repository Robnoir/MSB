using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Employee
{
    public class EmployeeDto
    {
        [Required]public Guid EmployeeId { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Role { get; set; }

        //public ICollection<WareHouseModel> WareHouses { get; set; }
        //public ICollection<AddressModel> Addresses { get; set; }
        //public ICollection<DriverModel> Drivers { get; set; }

    }
}