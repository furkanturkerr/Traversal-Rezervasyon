using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class DestinationController : Controller
{
    private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    // GET
    private readonly UserManager<AppUser> _userManager;

    public DestinationController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public IActionResult Index()
    {
        var values = destinationManager.GetAll();
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.i = id;
        ViewBag.destid = id;
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.userid = value.Id;
        var values = destinationManager.TGetListWithGuide(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult Details(Destination destination)
    {
        return View();
    }
}