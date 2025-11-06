using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    
    [HttpGet]
    public IActionResult SıgnUp()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SıgnUp(UserRegisterViewModel p)
    {
        AppUser appUser = new AppUser()
        {
            Name = p.Name,
            Surname = p.SurName,
            Email = p.Mail,
            UserName = p.UserName,
        };
        if (ModelState.IsValid)
        {
            if (p.Password == p.ConfirmPassword)
            {
                var resault = await _userManager.CreateAsync(appUser, p.Password);
                if (resault.Succeeded)
                {
                    return RedirectToAction("SıgnIn", "Login");
                }
                else
                {
                    foreach (var item in resault.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
        }
        return View(p);
    }

    [HttpGet]
    public IActionResult SıgnIn()
    {
        return View();
    }
    
    [HttpPost]
    public async Task  <IActionResult> SıgnIn(SıgnViewModel p)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile", new { area = "Member"});
            }
            else
            {
                return RedirectToAction("SıgnIn", "Login");
            }
        }
        return View();
    }
}