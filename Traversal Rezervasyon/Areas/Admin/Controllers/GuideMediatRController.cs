using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.CQRS.Commands.GuideCommants;
using Traversal_Rezervasyon.CQRS.Queries.GuideQueries;
using Traversal_Rezervasyon.CQRS.Results.GuideResults;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
[AllowAnonymous]
public class GuideMediatRController : Controller
{
    private IMediator _mediator;
    public GuideMediatRController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Index()
    {
        var values = await _mediator.Send(new GetAllGuidQuery());
        return View(values);
    }

    [HttpGet]
    public async Task<IActionResult> GetGuides(int id)
    {
        var values = await _mediator.Send(new GetGuideByIdQuery(id));
        return View(values);
    }

    [HttpGet]
    public IActionResult AddGuide()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddGuide(CreateGuideCommants command)
    {
        await _mediator.Send(command);
        return RedirectToAction("Index");
    }
}