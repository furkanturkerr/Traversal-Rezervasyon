namespace Traversal_Rezervasyon.CQRS.Queries;

public class GetDestinationByIdQuery
{
    public int id { get; set; }
    
    public GetDestinationByIdQuery(int id)
    {
        this.id = id;
    }
}