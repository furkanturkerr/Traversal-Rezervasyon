using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class GuideManager : IGuideService
{
    private readonly IGuideDal _guideDal;
    public GuideManager(IGuideDal guideDal)
    {
        _guideDal = guideDal;
    }
    public void Add(Guide t)
    {
        _guideDal.Insert(t);
    }

    public void Delete(Guide t)
    {
        throw new NotImplementedException();
    }

    public void Edit(Guide t)
    {
        throw new NotImplementedException();
    }

    public List<Guide> GetAll()
    {
        return _guideDal.GetList();
    }

    public Guide GetById(int id)
    {
        throw new NotImplementedException();
    }
}