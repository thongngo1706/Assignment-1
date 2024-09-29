using static System.Formats.Asn1.AsnWriter;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public Store Store { get; set; }

        public DateTime OrderDate { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal Price { get; set; }

        // Navigation property for OrderDetails and Payment
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Payment Payment { get; set; }
    }

}
