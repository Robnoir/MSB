using System.ComponentModel.DataAnnotations;

namespace Application.Dto.AddWarehouse
{
    public class AddWarehouseDto
    {
        [Required] public string WarehouseName { get; set; }
        [Required] public int AddressId { get; set; }
        [Required] public int ShelfId { get; set; }
    }
}
