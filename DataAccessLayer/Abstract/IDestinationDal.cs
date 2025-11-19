using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer;

public interface IDestinationDal : IGenericDal<Destination>
{
    public Destination GetListWithGuide(int id);
}