using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Commend;

public class _CommendList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}