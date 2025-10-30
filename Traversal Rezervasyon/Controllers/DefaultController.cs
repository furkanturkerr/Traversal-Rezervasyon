using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}