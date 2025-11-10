using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;
    public AppUserManager(IAppUserDal appUserDal)
    {
        _appUserDal = appUserDal;
    }
    public void Add(AppUser t)
    {
        _appUserDal.Insert(t);
    }

    public void Delete(AppUser t)
    {
        _appUserDal.Delete(t);
    }

    public void Edit(AppUser t)
    {
        _appUserDal.Update(t);
    }

    public List<AppUser> GetAll()
    {
        return _appUserDal.GetList();
    }

    public AppUser GetById(int id)
    {
        return _appUserDal.GetById(id);
    }
}