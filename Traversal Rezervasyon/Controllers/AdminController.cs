using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Controllers;

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
}