using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer;

public interface IDestinationDal : IGenericDal<Destination>
{
    public List<Destination> GetListWithGuide(int id);
}