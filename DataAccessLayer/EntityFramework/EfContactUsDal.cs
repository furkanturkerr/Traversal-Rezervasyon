using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
{
    public List<ContactUs> GetListByTrue()
    {
        using (var context = new Context())
        {
            var values = context.ContactUses.Where(x => x.Status == true).ToList();
            return values;
        }
    }

    public List<ContactUs> GetListByFalse()
    {
        using (var context = new Context())
        {
            var values = context.ContactUses.Where(x => x.Status == false).ToList();
            return values;
        }
    }

    public void ContactUsStatusChange(int id)
    {
        throw new NotImplementedException();
    }
}