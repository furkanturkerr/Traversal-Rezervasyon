using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Error404(int code)
    {
        return View();
    }
}