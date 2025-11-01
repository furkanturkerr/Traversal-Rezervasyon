using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

public class DestinationController : Controller
{
    private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    // GET
    public IActionResult Index()
    {
        var values = destinationManager.GetAll();
        return View(values);
    }
}