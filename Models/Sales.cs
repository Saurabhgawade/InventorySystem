using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }
       
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }


        // Foreign key
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]

        public int ProductId { get; set; }

        // Navigation property
        public Order? Order { get; set; }

        public Product? product { get; set; }
    }
}
