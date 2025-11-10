using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class UserController : Controller
{
    private readonly IAppUserService _appUserService;
    private readonly IRezervationService _rezervationService;
    public UserController(IAppUserService appUserService, IRezervationService rezervationService)
    {
        _rezervationService = rezervationService;
        _appUserService = appUserService;
    }
    
    public IActionResult Index()
    {
        var values = _appUserService.GetAll();
        return View(values);
    }

    public IActionResult DeleteUser(int id)
    {
        var values = _appUserService.GetById(id);
        _appUserService.Delete(values);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateUser(int id)
    {
        var values = _appUserService.GetById(id);
        return View(values);
    }
    
    [HttpPost]
    public IActionResult UpdateUser(AppUser appUser)
    {
        _appUserService.Edit(appUser);
        return RedirectToAction("Index");
    }
    
    public IActionResult CommandUser(int id)
    {
        var values = _appUserService.GetById(id);
        return View(values);
    }
    
    public IActionResult RezervationUser(int id)
    {
        var values = _rezervationService.GetListWithRezervationByAccepted(id);
        return View(values);
    }
}