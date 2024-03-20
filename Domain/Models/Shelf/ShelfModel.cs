using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Shelf
{
    public class ShelfModel
    {
        [Key]
        public Guid ShelfId { get; set; }

        public int ShelfRow { get; set; }
        public int ShelfColumn { get; set; }
        public bool Occupancy { get; set; }

        [ForeignKey("WarehouseId")]
        public Guid WarehouseId { get; set; }
        public Warehouse.WarehouseModel Warehouse { get; set; }

        // [ForeignKey("BoxID")]
        // public Guid BoxID { get; set; }
        // public Address Address { get; set; }

        // [ForeignKey("ItemID")]
        // public Guid ItemID { get; set; }
        // public Address Address { get; set; }

    }
}
