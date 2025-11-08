using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
public class DashbordController : Controller
{
    
    private readonly UserManager<AppUser> _userManager;
    
    public DashbordController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.username = values.Name + " " + values.Surname;
        ViewBag.userimage = values.ImageUrl;
        return View(values);
    }
}