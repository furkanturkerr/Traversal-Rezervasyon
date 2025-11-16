using DataAccessLayer.Concrate;
using Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;

namespace Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

public class UpdateDestinationCommendHendler
{
    private readonly Context _context;
    public UpdateDestinationCommendHendler(Context context)
    {
        _context = context;
    }

    public void Handle(UpdateDestinationCommend command)
    {
        var values = _context.Destinations.Find(command.Destinationid);
        values.City = command.City;
        values.DayNight = command.Daynight;
        values.Price = command.Price;
        _context.SaveChanges();
    }
}