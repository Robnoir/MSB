using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Transaction
{
    public class TransactionDto
    {
        [Key] // Specifies TransactionID as the primary key
        public int TransactionID { get; set; }

        public string Type { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Currency { get; set; }

        [ForeignKey("OrderID")] // Specifies OrderID as the foreign key
        public int OrderID { get; set; }

        // public Order Order { get; set; } // Navigation property

    }
}
