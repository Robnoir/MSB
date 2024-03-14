using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Repair
{
    public class RepairDto
    {
        [Key]
        public int? RepairId { get; set; }

        public int Amount { get; set; }

        [ForeignKey("OrderID")]
        public int OrderID { get; set; }
        // public Address Address { get; set; }

        [ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }
        // public Address Address { get; set; }
    }
}