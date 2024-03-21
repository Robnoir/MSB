using Domain.Models.UserModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.OrderModel
{
    public class OrderModel
    {
        [Key]
        public Guid OrderId { get; set; }
        public int OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        [ForeignKey("UserId")] // Inconsistency in naming/UserId is named Id in UserModel
        public Guid UserId { get; set; }
        public UserModels User { get; set; }

        // [ForeignKey("CarId")]
        // public int CarId { get; set; }
        // public Car.CarDto Car { get; set; }

        // [ForeignKey("RepairId")]
        // public int RepairId { get; set; }
        // public Repair.RepairDto Repair { get; set; }

        // [ForeignKey("WarehouseId")]
        // public int WarehouseId { get; set; }
        // public Warehouse.WarehouseDto Warehouse { get; set; }

        //[ForeignKey("AdressId")] // Return Address
        //public int AdressId { get; set; }
        //public Address.AddressModel Address { get; set; } // Inconsistency in naming/namespace Address(Model)/UserModel

        public string RepairNotes { get; set; } = "No notes";

    }
}
