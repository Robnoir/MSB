using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Pickup
{
    public class PickupReturnDto
    {
        [Key] // Specifies PickupReturnID as the primary key
        public int PickupReturnID { get; set; }

        [ForeignKey("BoxID")] // Specifies BoxID as the foreign key
        public int BoxID { get; set; }

        public Box Box { get; set; } // Navigation property

        [ForeignKey("OrderID")] // Specifies OrderID as the foreign key
        public int OrderID { get; set; }

        public Order Order { get; set; } // Navigation property

        [ForeignKey("CarID")] // Specifies CarID as the foreign key
        public int CarID { get; set; }
        public Car Car { get; set; } // Navigation property
    }
}