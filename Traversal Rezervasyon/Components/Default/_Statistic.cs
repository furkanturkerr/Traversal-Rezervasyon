using BusinessLayer.Abstract;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _Statistic : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        using var c = new Context();
        ViewBag.v1 = c.Destinations.Count();
        ViewBag.v2 = c.Guides.Count();
        ViewBag.v3 = "285";
        return View();
    }
}