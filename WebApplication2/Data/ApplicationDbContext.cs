using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Data;  


namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }  // Remove the redundant object here
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
