namespace Traversal_Rezervasyon.CQRS.Results.DestinationResult;

public class GetAllDestinationQueryReult
{
    public int id { get; set; }
    public string city { get; set; }
    public string daynight { get; set; }
    public double price { get; set; }
    public string capacity { get; set; }
}