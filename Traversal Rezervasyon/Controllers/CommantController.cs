using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

public class CommantController : Controller
{
    private CommandManager _commandManager = new CommandManager(new EfCommendDal());
    private readonly UserManager<AppUser> _userManager;
    
    public CommantController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public PartialViewResult AddCommend()
    {
        //ViewBag.destid = id;
        //var value = await _userManager.FindByNameAsync(User.Identity.Name);
        //ViewBag.userid = value.Id;
        return PartialView();
    }

    [HttpPost]
    public IActionResult AddCommend(Commend commend)
    {
        commend.CommendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        commend.CommendState = "true";
        _commandManager.Add(commend);
        return RedirectToAction("Index", "Destination");
    }
}