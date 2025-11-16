using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;

namespace Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

public class CreateDestinationComandHandler
{
    private readonly Context _context;
    public CreateDestinationComandHandler(Context context)
    {
        _context = context;
    }

    public void Handle(CreateDestinationCommand command)
    {
        _context.Destinations.Add(new Destination
        {
            City = command.City,
            DayNight = command.DayNight,
            Price = command.Price,
            Capacity = command.Capacity,
            Status = true
        });
        
        _context.SaveChanges();
    }
}