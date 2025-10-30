using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class About2Manager :  IAbout2Service
{
    private IAbout2Dal _about2Dal;

    public About2Manager(IAbout2Dal about2Dal)
    {
        _about2Dal = about2Dal;
    }
    
    public void Add(About2 t)
    {
        _about2Dal.Insert(t);
    }

    public void Delete(About2 t)
    {
        _about2Dal.Delete(t);
    }

    public void Edit(About2 t)
    {
        _about2Dal.Update(t);
    }

    public List<About2> GetAll()
    {
        return _about2Dal.GetList();
    }

    public About2 GetById(int id)
    {
        throw new NotImplementedException();
    }
}