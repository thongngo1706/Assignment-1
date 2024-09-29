using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;


namespace WebApplication2.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Seed Stores
                if (!context.Stores.Any())
                {
                    context.Stores.AddRange(new List<Store>()
                    {
                        new Store()
                        {
                            StoreLocation = "123 Coffee St",
                            Event = "Buy 1 Get 1 Free"
                        },
                        new Store()
                        {
                            StoreLocation = "456 Latte Ave",
                            Event = "20% Off"
                        },
                        new Store()
                        {
                            StoreLocation = "789 Espresso Blvd",
                            Event = "Happy Hour Discount"
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "Espresso",
                            Price = 3.5M
                        },
                        new Product()
                        {
                            ProductName = "Latte",
                            Price = 4.0M
                        },
                        new Product()
                        {
                            ProductName = "Cappuccino",
                            Price = 4.5M
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Customers
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            CustomerName = "John Doe",
                            Email = "john@example.com",
                            CustomerAddress = "123 Coffee St",
                            Reward = 100
                        },
                        new Customer()
                        {
                            CustomerName = "Jane Smith",
                            Email = "jane@example.com",
                            CustomerAddress = "456 Latte Ave",
                            Reward = 150
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Orders
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(new List<Order>()
                    {
                        new Order()
                        {
                            CustomerID = context.Customers.First().CustomerID,
                            StoreID = context.Stores.First().StoreID,
                            OrderDate = DateTime.Now,
                            PaymentStatus = "Completed",
                            DeliveryMethod = "Pickup",
                            Price = 10.0M
                        },
                        new Order()
                        {
                            CustomerID = context.Customers.Skip(1).First().CustomerID,
                            StoreID = context.Stores.Skip(1).First().StoreID,
                            OrderDate = DateTime.Now,
                            PaymentStatus = "Pending",
                            DeliveryMethod = "Delivery",
                            Price = 20.0M
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Order Details
                if (!context.OrderDetails.Any())
                {
                    context.OrderDetails.AddRange(new List<OrderDetails>()
                    {
                        new OrderDetails()
                        {
                            OrderID = context.Orders.First().OrderID,
                            ProductID = context.Products.First().ProductID,
                            Quantity = 2
                        },
                        new OrderDetails()
                        {
                            OrderID = context.Orders.First().OrderID,
                            ProductID = context.Products.Skip(1).First().ProductID,
                            Quantity = 1
                        },
                        new OrderDetails()
                        {
                            OrderID = context.Orders.Skip(1).First().OrderID,
                            ProductID = context.Products.Skip(2).First().ProductID,
                            Quantity = 3
                        }
                    });
                    context.SaveChanges();
                }

                // Seed Payments
                if (!context.Payments.Any())
                {
                    context.Payments.AddRange(new List<Payment>()
                    {
                        new Payment()
                        {
                            OrderID = context.Orders.First().OrderID,
                            PaymentMethod = "CreditCard",
                            PaymentDate = DateTime.Now,
                            PaymentAmount = 10.0M
                        },
                        new Payment()
                        {
                            OrderID = context.Orders.Skip(1).First().OrderID,
                            PaymentMethod = "Cash",
                            PaymentDate = DateTime.Now,
                            PaymentAmount = 20.0M
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

     /*     public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
          {
              using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
              {
                  var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                  if (!await roleManager.RoleExistsAsync("Admin"))
                      await roleManager.CreateAsync(new IdentityRole("Admin"));

                  if (!await roleManager.RoleExistsAsync("Customer"))
                      await roleManager.CreateAsync(new IdentityRole("Customer"));

                  var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                  string adminUserEmail = "admin@coffeeshop.com";

                  var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                  if (adminUser == null)
                  {
                      var newAdmin = new Customer()
                      {
                          UserName = "admin",
                          Email = adminUserEmail,
                          EmailConfirmed = true,
                          CustomerAddress = "Admin Office"
                      };
                      await userManager.CreateAsync(newAdmin, "Admin@1234");
                      await userManager.AddToRoleAsync(newAdmin, "Admin");
                  }

                  string customerEmail = "customer@coffeeshop.com";

                  var customerUser = await userManager.FindByEmailAsync(customerEmail);
                  if (customerUser == null)
                  {
                      var newCustomer = new Customer()
                      {
                          UserName = "customer",
                          Email = customerEmail,
                          EmailConfirmed = true,
                          CustomerAddress = "Customer Home"
                      };
                      await userManager.CreateAsync(newCustomer, "Customer@1234");
                      await userManager.AddToRoleAsync(newCustomer, "Customer");
                  }
              }
          }*/
    }
}
