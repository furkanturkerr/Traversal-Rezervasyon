using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICommandService : IGenericService<Commend>
{
    List<Commend> TGetDestinationBYıD(int id);
    List<Commend> TGetListCommandWithDestination();
}