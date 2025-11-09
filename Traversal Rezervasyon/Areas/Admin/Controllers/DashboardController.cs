using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}