using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IContactUsService : IGenericService<ContactUs>
{
    List<ContactUs> TGetListByTrue();
    List<ContactUs> TGetListByFalse();
    void TContactUsStatusChange(int id);
}