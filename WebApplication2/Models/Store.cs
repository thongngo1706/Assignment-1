using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Store
    {
        [Key]
        public int StoreID { get; set; }
        public string StoreLocation { get; set; }
        public string Event { get; set; }

        // Navigation property for Orders
        public ICollection<Order> Orders { get; set; }
    }

}
