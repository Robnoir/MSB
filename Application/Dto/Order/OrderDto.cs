using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Order
{
    public class OrderDto
    {
        [Required] public int OrderId { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] public decimal TotalCost { get; set; }
        public string? OrderStatus { get; set; }
        [Required] public int UserId { get; set; }
        public User.UserDto User { get; set; }
        // [Required] public int CarId { get; set; } // Commented out to avoid error
        public int RepairId { get; set; }
        // [Required] public int WarehouseId { get; set; } // Commented out to avoid error
        // [Required] public int AdressId { get; set; } // Commented out to avoid error
        public string RepairNotes { get; set; } = "No notes";
    }
}
