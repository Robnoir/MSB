using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Box
{
    public class BoxDto
    {
        public Guid BoxId { get; set; }
        // Is type and size the same thing?
        [Required] public string Type { get; set; }
        [Required] public int TimesUsed { get; set; }
        [Required] public int Stock { get; set; }
        [Required] public string ImageUrl { get; set; }
        [Required] public string? UserNotes { get; set; }
        [ForeignKey("OrderId")]
        [Required] public int OrderId { get; set; }
        [Required] public string Size { get; set; }





    }
}