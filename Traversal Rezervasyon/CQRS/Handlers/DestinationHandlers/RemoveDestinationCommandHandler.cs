using DataAccessLayer.Concrate;
using Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;

namespace Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

public class RemoveDestinationCommandHandler
{
    private readonly Context _context;
    public RemoveDestinationCommandHandler(Context context)
    {
        _context = context;
    }

    public void Handle(RemoveDestinationCommand command)
    {
        var values = _context.Destinations.Find(command.Id);
        _context.Destinations.Remove(values);
        _context.SaveChanges();
    }
}