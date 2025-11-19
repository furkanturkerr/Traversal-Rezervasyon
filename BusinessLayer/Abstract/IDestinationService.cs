using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IDestinationService : IGenericService<Destination>
{
    public Destination TGetListWithGuide(int id);

}