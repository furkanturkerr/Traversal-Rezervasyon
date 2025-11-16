using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;
using Traversal_Rezervasyon.CQRS.Queries;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class DestinationCQRSController : Controller
{
    private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
    private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
    
    public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler)
    {
        _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
        _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
    }

    public IActionResult Index()
    {
        var values = _getAllDestinationQueryHandler.Handle();
        return View(values);
    }
    
    public IActionResult GetDestinationById(int id)
    {
        var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
        return View(values);
    }
}