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
    
    [HttpPost]
    public async Task<IActionResult> Index(UserEditViewModel p)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (p.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(p.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var savelocaation = resource + "/wwwroot/userimages/" + imageName;
            var stream = new FileStream(savelocaation, FileMode.Create);
            await p.Image.CopyToAsync(stream);
            user.ImageUrl = "/userimages/" + imageName;
        }
        user.Name = p.Name;
        user.Surname = p.SurName;
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Pasword);
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return RedirectToAction("SıgnIn", "Login");
        }

        return View();
    }
}