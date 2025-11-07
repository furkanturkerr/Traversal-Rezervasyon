using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
public class RezervationController : Controller
{
    public IActionResult MyCurrentRezervation()
    {
        return View();
    }
    
    public IActionResult MyOldRezervation()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult NewRezervation()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult NewRezervation(Rezervation p)
    {
        return View();
    }
}