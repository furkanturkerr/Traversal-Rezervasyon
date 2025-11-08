using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class RezervationManager : IRezervationService
{
    private readonly IRezervationDal _rezervationDal;
    public RezervationManager(IRezervationDal rezervationDal)
    {
        _rezervationDal = rezervationDal;
    }
    
    public void Add(Rezervation t)
    {
        _rezervationDal.Insert(t);
    }

    public void Delete(Rezervation t)
    {
        throw new NotImplementedException();
    }

    public void Edit(Rezervation t)
    {
        throw new NotImplementedException();
    }

    public List<Rezervation> GetAll()
    {
        throw new NotImplementedException();
    }

    public Rezervation GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Rezervation> GetListWithRezervationByWaitAppRoval(int id)
    {
        return _rezervationDal.GetListWithRezervationByWaitAppRoval(id);
    }

    public List<Rezervation> GetListWithRezervationByPrevius(int id)
    {
        return _rezervationDal.GetListWithRezervationByPrevius(id);
    }

    public List<Rezervation> GetListWithRezervationByAccepted(int id)
    {
        return _rezervationDal.GetListWithRezervationByAccepted(id);
    }
}