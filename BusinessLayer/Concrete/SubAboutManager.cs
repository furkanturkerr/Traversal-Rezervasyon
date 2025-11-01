using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SubAboutManager : ISubAboutService
{
    private ISubAboutDal _subaboutDal;

    public SubAboutManager(ISubAboutDal subaboutDal)
    {
        _subaboutDal = subaboutDal;
    }
    
    public void Add(SubAbout t)
    {
        _subaboutDal.Insert(t);
    }

    public void Delete(SubAbout t)
    {
        _subaboutDal.Delete(t);
    }

    public void Edit(SubAbout t)
    {
        _subaboutDal.Update(t);
    }

    public List<SubAbout> GetAll()
    {
        return _subaboutDal.GetList();
    }

    public SubAbout GetById(int id)
    {
        throw new NotImplementedException();
    }
}