using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;
[AllowAnonymous]
public class AdminController : Controller
{
    // GET
    public PartialViewResult PartialHeader()
    {
        return PartialView();
    }
    
    public PartialViewResult PartialAppBrandDemo()
    {
        return PartialView();
    }

    public PartialViewResult PartialSidebar()
    {
        return PartialView();
    }
    
    public PartialViewResult PartialNavbar()
    {
        return PartialView();
    }
    
    public PartialViewResult PartialFooter()
    {
        return PartialView();
    }
    
    public PartialViewResult PartialScript()
    {
        return PartialView();
    }
}