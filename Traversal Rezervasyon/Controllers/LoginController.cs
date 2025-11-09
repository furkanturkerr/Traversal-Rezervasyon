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
    
    [AllowAnonymous]
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> SignUp(UserRegisterViewModel p)
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
                    return RedirectToAction("SignIn", "Login");
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
    [AllowAnonymous]
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    
    [HttpPost]
    public async Task  <IActionResult> SignIn(SıgnViewModel p)
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
                return RedirectToAction("SignIn", "Login");
            }
        }
        return View();
    }
}