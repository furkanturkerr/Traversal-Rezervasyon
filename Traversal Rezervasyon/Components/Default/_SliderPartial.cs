using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.ViewComponents.Default;

public class _SliderPartial :  ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}