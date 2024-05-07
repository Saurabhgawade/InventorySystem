using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //Navigation Property
        public ICollection<Product>? Products { get; set; }
    }
}
