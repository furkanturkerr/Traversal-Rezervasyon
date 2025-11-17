using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Rezervasyon.Components;

public class _PopularDestinations : ViewComponent
{
    private DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
    public IViewComponentResult Invoke()
    {
        var destinations = destinationManager.GetAll();
        return View(destinations);
    }
}