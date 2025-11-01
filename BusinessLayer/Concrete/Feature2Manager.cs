using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class Feature2Manager : IFeature2Service
{
    private readonly IFeature2Dal _destinationDal;

    public Feature2Manager(IFeature2Dal destinationDal)
    {
        _destinationDal = destinationDal;
    }
    
    public void Add(Feature2 t)
    {
        _destinationDal.Insert(t);
    }

    public void Delete(Feature2 t)
    {
        _destinationDal.Delete(t);
    }

    public void Edit(Feature2 t)
    {
        _destinationDal.Update(t);
    }

    public List<Feature2> GetAll()
    {
        return _destinationDal.GetList();
    }

    public Feature2 GetById(int id)
    {
        throw new NotImplementedException();
    }
}