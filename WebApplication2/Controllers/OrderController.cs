using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var Orders = _context.Orders.ToList();
        return View(Orders);
    }
    [HttpPost]
    public IActionResult PlaceOrder(int productId)
    {
        // Xử lý logic đặt hàng tại đây
        return RedirectToAction("ConfirmOrder");
    }

    public IActionResult ConfirmOrder()
    {
        return View();
    }
}