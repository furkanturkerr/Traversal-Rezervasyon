namespace Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;

public class UpdateDestinationCommend
{
    public int Destinationid { get; set; }
    public string City { get; set; }
    public string Daynight { get; set; }
    public double Price { get; set; }
}