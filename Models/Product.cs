using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }


        //Foreign Key
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }

        //Navigation Property
        public Category? category { get; set; }

        public Supplier? supplier { get; set; }


        //Navigation property
        public ICollection<Sales>? Sales { get; set; }



    }
}
