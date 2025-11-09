using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;

[Area("Admin")]
public class DestinationController : Controller
{
    private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IActionResult Index()
    {
        var values = destinationManager.GetAll();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult AddDestination()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddDestination(Destination destination)
    {
        destinationManager.Add(destination);
        return RedirectToAction("Index");
    }
    
    public IActionResult DeleteDestination(int id)
    {
        var value = destinationManager.GetById(id);
        destinationManager.Delete(value);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult UpdateDestination(int id)
    {
        var value = destinationManager.GetById(id);
        return View(value);
    }
    
    [HttpPost]
    public IActionResult UpdateDestination(Destination destination)
    {
        destinationManager.Edit(destination);
        return RedirectToAction("Index");
    }
}