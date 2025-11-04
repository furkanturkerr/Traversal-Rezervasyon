using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    [HttpGet]
    public IActionResult SıgnUp()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SıgnIn()
    {
        return View();
    }
}