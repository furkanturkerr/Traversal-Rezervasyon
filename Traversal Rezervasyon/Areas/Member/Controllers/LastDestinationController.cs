using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Member.Controllers;
[Area("Member")]
public class LastDestinationController : Controller
{
    // GET
    private readonly IDestinationService _destinationService;
    public LastDestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
 
    public ViewResult Index()
    {
        var values = _destinationService.TGetLast4Destinations();
        return View(values);
    }
}