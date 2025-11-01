using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Default;

public class _Testimonial : ViewComponent
{
    public virtual IViewComponentResult Invoke()
    {
        return View();
    }
}