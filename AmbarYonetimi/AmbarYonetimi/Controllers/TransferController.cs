// TransferController.cs
using Microsoft.AspNetCore.Mvc;

public class TransferController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(TransferModel model)
    {
        // Transfer işlemi burada yapılacak
        return Json(new { success = true, message = "Transfer başarılı" });
    }
}