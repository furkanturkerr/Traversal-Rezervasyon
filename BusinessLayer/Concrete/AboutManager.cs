using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }
    public void Add(About t)
    {
        _aboutDal.Insert(t);
    }

    public void Delete(About t)
    {
        _aboutDal.Delete(t);
    }

    public void Edit(About t)
    {
        _aboutDal.Update(t);
    }

    public List<About> GetAll()
    {
        return _aboutDal.GetList();
    }

    public About GetById(int id)
    {
        throw new NotImplementedException();
    }
}