using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Warehouse
{
    public class WarehouseModel
    {
        [Key]
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;

        // Commented out to avoid errors

        //[ForeignKey("AdressId")] // Return Address
        //public Guid AdressId { get; set; }
        //public Address.AddressModel Address { get; set; } // Inconsistency in naming/namespace Address(Model)/UserModel

        //[ForeignKey("ShelfId")] // Return Shelf
        //public Guid ShelfId { get; set; }
        //public Shelf.ShelfModel Shelf { get; set; } // Fix before pushing
    }
}
