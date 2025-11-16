using DataAccessLayer.Concrate;
using Traversal_Rezervasyon.CQRS.Queries;
using Traversal_Rezervasyon.CQRS.Results.DestinationResult;

namespace Traversal_Rezervasyon.CQRS.Handlers.DestinationResult;

public class GetDestinationByIdQueryHandler
{
    private readonly Context _context;

    public GetDestinationByIdQueryHandler(Context context)
    {
        _context = context;
    }

    public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery _query)
    {
        var values = _context.Destinations.Find(_query.id);
        return new GetDestinationByIdQueryResult
        {
            Destinationid = values.DestinationId,
            City = values.City,
            Daynight = values.DayNight
        };
    }
}