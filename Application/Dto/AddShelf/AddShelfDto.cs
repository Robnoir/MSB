using System.ComponentModel.DataAnnotations;

namespace Application.Dto.AddShelf
{
    public class AddShelfDto
    {
        [Required] public int ShelfRow { get; set; }
        [Required] public int ShelfColumn { get; set; }
        [Required] public bool Occupancy { get; set; }
        [Required] public Guid WarehouseId { get; set; }

    }
}