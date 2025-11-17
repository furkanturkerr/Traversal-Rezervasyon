using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components.Commend;

public class _CommendList : ViewComponent
{
    private CommandManager _commandManager = new CommandManager(new EfCommendDal());
    public IViewComponentResult Invoke(int id)
    {
        var values = _commandManager.TGetListCommandWithUserandDestination(id);
        return View(values);
    }
}