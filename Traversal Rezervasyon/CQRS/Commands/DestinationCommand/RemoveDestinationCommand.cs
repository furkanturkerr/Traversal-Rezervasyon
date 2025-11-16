namespace Traversal_Rezervasyon.CQRS.Commands.DestinationCommand;

public class RemoveDestinationCommand
{
    public int Id { get; set; }
    
    public RemoveDestinationCommand(int id)
    {
        this.Id = id;
    }
}