using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private IFeatureDal _featureDal;

    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }
    
    public void Add(Feature t)
    {
        _featureDal.Insert(t);
    }

    public void Delete(Feature t)
    {
        _featureDal.Delete(t);
    }

    public void Edit(Feature t)
    {
        _featureDal.Update(t);
    }

    public List<Feature> GetAll()
    {
        return _featureDal.GetList();
    }

    public Feature GetById(int id)
    {
        throw new NotImplementedException();
    }
}