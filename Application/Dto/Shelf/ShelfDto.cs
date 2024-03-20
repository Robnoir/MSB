using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Shelf
{
    public class ShelfDto
    {
        [Required] public Guid ShelfId { get; set; }
        [Required] public int ShelfRow { get; set; }
        [Required] public int ShelfColumn { get; set; }
        [Required] public bool Occupancy { get; set; }
        [Required] public Guid WarehouseId { get; set; }

    }
}