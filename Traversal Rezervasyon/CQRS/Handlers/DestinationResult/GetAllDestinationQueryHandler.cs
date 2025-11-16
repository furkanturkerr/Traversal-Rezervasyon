using DataAccessLayer.Concrate;
using Microsoft.EntityFrameworkCore;
using Traversal_Rezervasyon.CQRS.Queries;
using Traversal_Rezervasyon.CQRS.Results.DestinationResult;

namespace Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

public class GetAllDestinationQueryHandler
{
    private readonly Context _context;
    
    public GetAllDestinationQueryHandler(Context context)
    {
        _context = context;
    }

    public List<GetAllDestinationQueryReult> Handle()
    {
        var values = _context.Destinations.Select(x => new GetAllDestinationQueryReult
        {
            id = x.DestinationId,
            capacity = x.City,
            daynight = x.DayNight,
            price = x.Price
        }).AsNoTracking().ToList();
        return values;
    }
}