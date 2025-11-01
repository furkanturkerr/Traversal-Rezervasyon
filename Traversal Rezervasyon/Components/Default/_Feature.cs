using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _Feature : ViewComponent
{
    private FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
    public IViewComponentResult Invoke()
    {
        var values = featureManager.GetAll();
        return View(values);
    }
}