using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _Feature2 :  ViewComponent
{
    private Feature2Manager feature2Manager = new Feature2Manager(new EfFeature2Dal());
    public IViewComponentResult Invoke()
    {
        var values = feature2Manager.GetAll();
        return View(values);
    }
}