using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;

[Area("Admin")]
public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;
    
    public DestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
    
    public IActionResult Index()
    {
        var values = _destinationService.GetAll();
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
        _destinationService.Add(destination);
        return RedirectToAction("Index"); 
    }
    
    public IActionResult DeleteDestination(int id)
    {
        var value = _destinationService.GetById(id);
        _destinationService.Delete(value);
        return RedirectToAction("Index"); 
    }
    
    [HttpGet]
    public IActionResult UpdateDestination(int id)
    {
        var value = _destinationService.GetById(id);
        return View(value);
    }
    
    [HttpPost]
    public IActionResult UpdateDestination(Destination destination)
    {
        _destinationService.Edit(destination);
        return RedirectToAction("Index");  
    }
}