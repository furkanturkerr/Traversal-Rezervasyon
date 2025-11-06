using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Member.Models;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
[Route("[area]/[controller]/[action]")]
public class ProfileController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public ProfileController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UserEditViewModel userEditViewModel = new UserEditViewModel();
        userEditViewModel.Name = values.Name;
        userEditViewModel.SurName = values.Surname;
        userEditViewModel.Mail = values.Email;
        userEditViewModel.PhoneNumber = values.PhoneNumber;
        return View(userEditViewModel);
    }
}