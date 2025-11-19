using BusinessLayer.Abstract;
using DataAccessLayer;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class DestinationManager : IDestinationService
{
    private readonly IDestinationDal  _destinationDal;

    public DestinationManager(IDestinationDal destinationDal)
    {
        _destinationDal = destinationDal;
    }
    
    public void Add(Destination t)
    {
        _destinationDal.Insert(t);
    }

    public void Delete(Destination t)
    {
        _destinationDal.Delete(t);
    }

    public void Edit(Destination t)
    {
        _destinationDal.Update(t);
    }

    public List<Destination> GetAll()
    {
        return _destinationDal.GetList();
    }

    public Destination GetById(int id)
    {
        return _destinationDal.GetById(id);
    }

    public Destination TGetListWithGuide(int id)
    {
        return _destinationDal.GetListWithGuide(id);
    }
}