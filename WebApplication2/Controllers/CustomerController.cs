using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

public class CustomerController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var Customers = _context.Customers.ToList();  // Hoặc đổi tên Customer thành User trong mô hình
        return View(Customers);
    }
            
            }
