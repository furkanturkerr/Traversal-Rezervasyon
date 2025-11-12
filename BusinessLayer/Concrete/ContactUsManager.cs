using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactUsManager : IContactUsService
{
    private readonly IContactUsDal _contactUsDal;
    public ContactUsManager(IContactUsDal contactUsDal)
    {
        _contactUsDal = contactUsDal;
    }
    public void Add(ContactUs t)
    {
        throw new NotImplementedException();
    }

    public void Delete(ContactUs t)
    {
        throw new NotImplementedException();
    }

    public void Edit(ContactUs t)
    {
        throw new NotImplementedException();
    }

    public List<ContactUs> GetAll()
    {
        return _contactUsDal.GetList();
    }

    public ContactUs GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<ContactUs> TGetListByTrue()
    {
        return _contactUsDal.GetListByTrue();
    }

    public List<ContactUs> TGetListByFalse()
    {
        return _contactUsDal.GetListByFalse();
    }

    public void TContactUsStatusChange(int id)
    {
        throw new NotImplementedException();
    }
}