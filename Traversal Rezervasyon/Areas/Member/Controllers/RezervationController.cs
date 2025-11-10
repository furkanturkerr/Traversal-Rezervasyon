using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
public class RezervationController : Controller
{
    private readonly IDestinationService _destinationService;
    private readonly IRezervationService _rezervationService;
    private readonly UserManager<AppUser> _userManager;

    public RezervationController(IDestinationService destinationService, IRezervationService rezervationService,
        UserManager<AppUser> userManager)
    {
        _destinationService = destinationService;
        _rezervationService = rezervationService;
        _userManager = userManager;
    }
    
    public async Task<IActionResult> MyCurrentRezervation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valuesList = _rezervationService.GetListWithRezervationByAccepted(values.Id);
        return View(valuesList);
    }
    
    public async Task<IActionResult> MyOldRezervation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valuesList = _rezervationService.GetListWithRezervationByPrevius(values.Id);
        return View(valuesList);
    }


    public async Task<IActionResult> MyApprovaRezervation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valuesList = _rezervationService.GetListWithRezervationByWaitAppRoval(values.Id);
        return View(valuesList);
    }
    
    [HttpGet]
    public IActionResult NewRezervation()
    {
        List<SelectListItem> values = (from x in _destinationService.GetAll() select new SelectListItem
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
        try
        {
            p.AppUserId = 1;
            p.Status = "Onay Bekliyor";
            _rezervationService.Add(p);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }
}