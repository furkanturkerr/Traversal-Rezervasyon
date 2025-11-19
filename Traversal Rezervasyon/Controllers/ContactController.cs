using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class ContactController : Controller
{
    private readonly ContactUsManager _contactUsManager = new ContactUsManager(new EfContactUsDal());
    public IActionResult Index()
    {
        return View();
    }
}