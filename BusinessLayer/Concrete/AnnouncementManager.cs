using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AnnouncementManager : IAnnouncementService
{
    private readonly IAnnouncementDal _announcementDal;
    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }
    public void Add(Announcement t)
    {
        _announcementDal.Insert(t);
    }

    public void Delete(Announcement t)
    {
        _announcementDal.Delete(t);
    }

    public void Edit(Announcement t)
    {
        _announcementDal.Update(t);
    }

    public List<Announcement> GetAll()
    {
        return _announcementDal.GetList();
    }

    public Announcement GetById(int id)
    {
        return _announcementDal.GetById(id);
    }
}