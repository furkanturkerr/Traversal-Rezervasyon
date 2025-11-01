using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _SubAbout : ViewComponent
{
    private SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
    public IViewComponentResult Invoke()
    {
        var value =  subAboutManager.GetAll();
        return View(value);
    }
}