using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/Role")]
public class RoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public RoleController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }
    
    [Route("CreateRole")]
    [HttpGet]
    public IActionResult CreateRole()
    {
        return View();
    }
    [Route("CreateRole")]
    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleModel model)
    {
        AppRole role = new AppRole()
        {
            Name = model.RoleName
        };
        var result = await _roleManager.CreateAsync(role);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}