using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Views.Shared.Components._MemberDashbord;

public class _GuidList : ViewComponent
{
    private GuideManager guideManager = new GuideManager(new EfGuideDal());
    
    public IViewComponentResult Invoke()
    { 
        var values = guideManager.GetAll();
        return View(values);
    }
}