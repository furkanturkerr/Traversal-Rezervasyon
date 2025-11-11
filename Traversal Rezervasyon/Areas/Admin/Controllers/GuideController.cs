using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class GuideController : Controller
{
    private readonly IGuideService _guideService;

    public GuideController(IGuideService guideService)
    {
        _guideService = guideService;
    }
    
    // GET
    public IActionResult Index()
    {
        var values = _guideService.GetAll();
        return View(values);
    }

    [HttpGet]
    public IActionResult AddGuide()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddGuide(Guide guide)
    {
        GuideValidator guideValidator = new GuideValidator();
        ValidationResult result = guideValidator.Validate(guide);
        if (result.IsValid)
        {
            _guideService.Add(guide);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in result.Errors )
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View();
        }
    }
    
    [HttpGet]
    public IActionResult EditGuide()
    {
        var values = _guideService.GetAll();
        return View(values);
    }
    
    [HttpPost]
    public IActionResult EditGuide(Guide guide)
    {
        _guideService.Edit(guide);
        return RedirectToAction("Index");
    }

    public IActionResult ChangtoTrue(int id)
    {
        return RedirectToAction("Index");
    }
    
    public IActionResult ChangtoFalse(int id)
    {
        return RedirectToAction("Index");
    }
}