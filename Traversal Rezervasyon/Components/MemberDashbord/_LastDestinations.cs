using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Views.Shared.Components._MemberDashbord;

public class _LastDestinations : ViewComponent
{
    private readonly IDestinationService _destinationService;
    public _LastDestinations(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
 
    public IViewComponentResult Invoke()
    {
         var values = _destinationService.TGetLast4Destinations();
         return View(values);
    }
}