using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public Status? status { get; set; }


        // Foreign key
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        // Navigation property
        public Customer? Customer { get; set; }
        public ICollection<Sales>? Sales { get; set; }
   
    }
}

namespace Inventory
{
    public enum Status
    {
        Completed,Pending,Failed
    }
}