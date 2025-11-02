using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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

    [HttpGet]
    public IActionResult Details(int id)
    {
        ViewBag.i = id;
        var values = destinationManager.GetById(id);
        return View(values);
    }

    [HttpPost]
    public IActionResult Details(Destination destination)
    {
        
        return View();
    }
}