using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
public class RezervationController : Controller
{
    private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    
    private RezervationManager rezervationManager = new RezervationManager(new EfRezervationDal());
    
    public IActionResult MyCurrentRezervation()
    {
        return View();
    }
    
    public IActionResult MyOldRezervation()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult NewRezervation()
    {
        List<SelectListItem> values = (from x in destinationManager.GetAll() select new SelectListItem
        {
            Text = x.City,
            Value = x.DestinationId.ToString()
        }).ToList();
        ViewBag.v = values;
        return View();
    }
    
    [HttpPost]
    public IActionResult NewRezervation(Rezervation p)
    {
        p.AppUserId = 3;
        p.Status = "False";
        rezervationManager.Add(p);
        return RedirectToAction("MyCurrentRezervation");
    }
}