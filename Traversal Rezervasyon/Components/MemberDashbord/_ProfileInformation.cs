using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Views.Shared.Components._MemberDashbord;

public class _ProfileInformation : ViewComponent  
{
    private readonly UserManager<AppUser> _userManager;

    public _ProfileInformation(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        @ViewBag.membername = values.UserName + " " + values.Surname;
        @ViewBag.memberPhone = values.PhoneNumber;
        @ViewBag.memberMail = values.Email;
        return View();
    }
}