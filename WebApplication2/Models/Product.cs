using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Navigation property for OrderDetails
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

}
