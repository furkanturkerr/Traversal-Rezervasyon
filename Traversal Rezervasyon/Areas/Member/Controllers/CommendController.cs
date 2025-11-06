using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;

[Area("Member")]
[AllowAnonymous]
public class CommendController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}