using MediatR;
using Traversal_Rezervasyon.CQRS.Results.GuideResults;

namespace Traversal_Rezervasyon.CQRS.Queries.GuideQueries;

public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
{
    public int id { get; set; }
    public GetGuideByIdQuery(int id)
    {
        this.id = id;
    }
}