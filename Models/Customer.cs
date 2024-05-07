using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }

        
        public ICollection<Order>? Orders { get; set; }
    }
}
