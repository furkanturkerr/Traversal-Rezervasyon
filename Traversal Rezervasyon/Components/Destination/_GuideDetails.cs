using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Destination;

public class _GuideDetails : ViewComponent
{
    private readonly IGuideService _guideService;
    public _GuideDetails(IGuideService guideService)
    {
        _guideService = guideService;
    }
    
    public IViewComponentResult Invoke()
    {
        var guide = _guideService.GetById(2);
        return View(guide);
    }
}