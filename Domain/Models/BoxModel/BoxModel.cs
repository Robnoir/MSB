using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.BoxModel
{
    public class BoxModel
    {
        [Key]
        public Guid BoxId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int TimesUsed { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string UserNotes { get; set; } = string.Empty;
        [ForeignKey("OrderId")]
        public Guid OrderId { get; set; }
        public Order.OrderModel Order { get; set; }
        public string Size { get; set; } = string.Empty;

    }
}
