using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Order
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        public string? OrderStatus { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User.UserDto User { get; set; }

        [ForeignKey("CarId")]
        public int CarId { get; set; }
        // public Car.CarDto Car { get; set; }

        [ForeignKey("RepairId")]
        public int RepairId { get; set; }
        // public Repair.RepairDto Repair { get; set; }

        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
        // public Warehouse.WarehouseDto Warehouse { get; set; }

        [ForeignKey("AdressId")] // Return Address
        public int AdressId { get; set; }
        // public Addreso Address { get; set; }

        public string RepairNotes { get; set; } = "No notes";
    }
}
