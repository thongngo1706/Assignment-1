using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

public class PaymentController : Controller
{
    private readonly ApplicationDbContext _context;

    public PaymentController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var payments = _context.Payments.ToList();
        return View(payments);
    }
    [HttpPost]
    public IActionResult ProcessPayment(int orderId, string paymentMethod)
    {
        // Xử lý thanh toán
        // Bạn có thể lưu thông tin thanh toán vào cơ sở dữ liệu
        return RedirectToAction("ConfirmPayment");
    }

    public IActionResult ConfirmPayment()
    {
        return View();
    }
}

