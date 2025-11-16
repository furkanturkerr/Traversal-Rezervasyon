using DataAccessLayer.Concrate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Traversal_Rezervasyon.CQRS.Queries.GuideQueries;
using Traversal_Rezervasyon.CQRS.Results.GuideResults;

namespace Traversal_Rezervasyon.CQRS.Handlers.GuideHendlers;

public class GetAllGuideQueryHendler: IRequestHandler<GetAllGuidQuery, List<GetAllGuideQueryResult>>
{
    private readonly Context _context;
    public GetAllGuideQueryHendler(Context context)
    {
        _context = context;
    }


    public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuidQuery request, CancellationToken cancellationToken)
    {
        return await _context.Guides.Select(x=> new GetAllGuideQueryResult
        {
            GuideId = x.GuideId,
            Name = x.Name,
            Description = x.Description,
            Image = x.Image
        }).AsNoTracking().ToListAsync();
    }
}