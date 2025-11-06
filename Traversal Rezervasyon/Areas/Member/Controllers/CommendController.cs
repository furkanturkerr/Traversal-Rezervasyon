using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;

[Area("Member")]
[AllowAnonymous]
public class CommendController : Controller
{
    private DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
    // GET
    public IActionResult Index()
    {
        var values = _destinationManager.GetAll();
        return View(values);
    }
}