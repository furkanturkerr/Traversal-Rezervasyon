using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfGuideDal :  GenericRepository<Guide>, IGuideDal
{
    public void ChangetoTrueByGuide(int id)
    {
        Context context = new Context();
        var values = context.Guides.Find(id);
        values.Status = true;
        context.SaveChanges();
    }

    public void ChangetoFalseByGuide(int id)
    {
        Context context = new Context();
        var values = context.Guides.Find(id);
        values.Status = false;
        context.SaveChanges();
    }
}