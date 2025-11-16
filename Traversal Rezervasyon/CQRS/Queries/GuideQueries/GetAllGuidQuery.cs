using MediatR;
using Traversal_Rezervasyon.CQRS.Results.GuideResults;

namespace Traversal_Rezervasyon.CQRS.Queries.GuideQueries;

public class GetAllGuidQuery : IRequest<List<GetAllGuideQueryResult>>
{
    
}