using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

public class CommantController : Controller
{
    private CommandManager _commandManager = new CommandManager(new EfCommendDal());
    
    [HttpGet]
    public PartialViewResult AddCommend(int id)
    {
        ViewBag.destid = id;
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