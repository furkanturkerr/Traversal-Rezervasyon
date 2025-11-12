using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class CityController : Controller
{
    private readonly IDestinationService _destinationService;

    public CityController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CitiList()
    {
        var jsonCİty = JsonConvert.SerializeObject(_destinationService.GetAll());
        return Json(jsonCİty);
    }

    [HttpPost]
    public IActionResult AddCityDestination(Destination destination)
    {
        destination.Status = true;
        destination.CoverImage = "#";
        destination.Details1 = "#";
        destination.Details2 = "#";
        destination.Image2 = "#";
        destination.Image = "#";
        destination.Description = "#";
        _destinationService.Add(destination);
        var values = JsonConvert.SerializeObject(destination); 
        return Json(values);
    }
    
    public IActionResult GetbyId(int id)
    {
        var values = _destinationService.GetById(id);
        var json = JsonConvert.SerializeObject(values);
        return Json(values);
    }
}