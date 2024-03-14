using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Shelf
{
    public class shelfDto
    {
        [Key]
        public int? ShelfId { get; set; }

        public int ShelfRow { get; set; }
        public int ShelfColumn { get; set; }
        public bool Occupancy { get; set; }

        [ForeignKey("WarehouseId")]
        public int WarehouseId { get; set; }
        // public Address Address { get; set; }

        [ForeignKey("BoxID")]
        public int BoxID { get; set; }
        // public Address Address { get; set; }

        [ForeignKey("ItemID")]
        public int ItemID { get; set; }
        // public Address Address { get; set; }
    }
}