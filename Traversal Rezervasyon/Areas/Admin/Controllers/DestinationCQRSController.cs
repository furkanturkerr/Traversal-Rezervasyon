using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;
using Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;
using Traversal_Rezervasyon.CQRS.Queries;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class DestinationCQRSController : Controller
{
    private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
    private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
    private readonly CreateDestinationComandHandler _createDestinationCommandHandler;
    private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
    private readonly UpdateDestinationCommendHendler _updateDestinationCommandHandler;
    
    public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, 
        GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, 
        CreateDestinationComandHandler createDestinationComandHandler, 
        RemoveDestinationCommandHandler removeDestinationCommandHandler,
        UpdateDestinationCommendHendler updateDestinationCommandHandler)
    {
        _updateDestinationCommandHandler = updateDestinationCommandHandler;
        _removeDestinationCommandHandler = removeDestinationCommandHandler;
        _createDestinationCommandHandler = createDestinationComandHandler;
        _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
        _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
    }

    public IActionResult Index()
    {
        var values = _getAllDestinationQueryHandler.Handle();
        return View(values);
    }
    
    [HttpGet]
    public IActionResult GetDestinationById(int id)
    {
        var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
        return View(values);
    }
    
    [HttpGet]
    public IActionResult UpdateDestination(UpdateDestinationCommend commend)
    {
        _updateDestinationCommandHandler.Handle(commend);
        return View();
    }
    
    [HttpGet]
    public IActionResult AddDestination()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddDestination(CreateDestinationCommand command)
    {
        _createDestinationCommandHandler.Handle(command);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteDestination(int id)
    {
        _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
        return RedirectToAction("Index");
    }
    
}