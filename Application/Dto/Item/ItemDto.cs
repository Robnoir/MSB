using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Item
{
    public class ItemDto
    {
        [Key]
        public int ItemId { get; set; }

        public double Weight { get; set; }
        public double Depth { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }


        [ForeignKey("OrderID")]
        public int OrderId { get; set; }
        public Order.OrderDto Order { get; set; }



    }
}