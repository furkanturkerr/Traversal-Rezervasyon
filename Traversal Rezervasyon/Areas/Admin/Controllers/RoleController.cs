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
    private readonly UserManager<AppUser> _userManager;

    public RoleController(RoleManager<AppRole> roleManager,  UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        var values = _roleManager.Roles.ToList();
        return View(values);
    }
    
    [Route("UserList")]
    public IActionResult UserList()
    {
        var values =_userManager.Users.ToList();
        return View(values);
    }

    [Route("AssignRole/{id}")]
    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        TempData["UserId"] = user.Id;
        var roles = _roleManager.Roles.ToList();
        var values = await _userManager.GetRolesAsync(user);
        List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
        foreach (var role in roles)
        {
            RoleAssignViewModel model = new RoleAssignViewModel();
            model.RoleName = role.Name;
            model.Roleid = role.Id;
            roleAssignViewModels.Add(model);
        }
        return View(roleAssignViewModels);
    }

    [HttpPost]
    [Route("AssignRole/{id}")]
    public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
    {
        var userid = (int)TempData["UserId"];
        var user = _userManager.Users.FirstOrDefault(x=>x.Id == userid);
        foreach (var role in model)
        {
            if (role.RoleExist)
            {
                await _userManager.AddToRoleAsync(user, role.RoleName);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
        }
        return RedirectToAction("UserList");
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
    
    [Route("DeleteRole/{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        await _roleManager.DeleteAsync(values);
        return RedirectToAction("Index");
    }
    
    [Route("UpdateRole/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        UpdateRoleVİewModel updateRoleVİewModel = new UpdateRoleVİewModel()
        {
            RoleId = values.Id,
            RoleName = values.Name
        };
        return View(updateRoleVİewModel);
    }

    [Route("UpdateRole/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateRole(UpdateRoleVİewModel model)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == model.RoleId);
        values.Name = model.RoleName;
        await _roleManager.UpdateAsync(values);
        return RedirectToAction("Index");
    }
    
    
}