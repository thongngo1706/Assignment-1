using static System.Formats.Asn1.AsnWriter;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }  // Primary Key

        
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string CustomerAddress { get; set; }

        public int Reward { get; set; }  // Reward points earned by the customer
    }
}
