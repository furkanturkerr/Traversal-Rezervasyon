

using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IContactUsDal : IGenericDal<ContactUs>
{
    List<ContactUs> GetListByTrue();
    List<ContactUs> GetListByFalse();
    void ContactUsStatusChange(int id);
}