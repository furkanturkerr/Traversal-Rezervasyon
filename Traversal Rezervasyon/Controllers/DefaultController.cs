using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}