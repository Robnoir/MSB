using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Warehouse
{
    public class WarehouseDto
    {
        [Required] public Guid WarehouseId { get; set; }
        [Required] public string WarehouseName { get; set; }
        [Required] public int AddressId { get; set; }
        [Required] public int ShelfId { get; set; }
    }
}
