using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}