using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;

public class MessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}