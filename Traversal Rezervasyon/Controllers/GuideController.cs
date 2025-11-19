using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class GuideController : Controller
{
    private GuideManager _guideManager = new GuideManager(new EfGuideDal());
    
    public IActionResult Index()
    {
        var values = _guideManager.GetAll();
        return View(values);
    }
}