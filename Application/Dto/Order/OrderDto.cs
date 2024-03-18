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
        [Required] public int CarId { get; set; }
        public int RepairId { get; set; }
        [Required] public int WarehouseId { get; set; }
        [Required] public int AdressId { get; set; }
        public string RepairNotes { get; set; } = "No notes";
    }
}
