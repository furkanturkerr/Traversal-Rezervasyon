using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;

[Area("Admin")]
[AllowAnonymous]
public class CommandController : Controller
{
    private readonly ICommandService _commandService;

    public CommandController(ICommandService commandService)
    {
        _commandService = commandService;
    }
    
    public IActionResult Index()
    {
        var values = _commandService.TGetListCommandWithDestination();
        return View(values);
    }

    public IActionResult DeleteCommand(int id)
    {
        var values = _commandService.GetById(id);
        _commandService.Delete(values);
        return RedirectToAction("Index");
    }
}