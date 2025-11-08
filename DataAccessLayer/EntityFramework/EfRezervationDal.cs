using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfRezervationDal : GenericRepository<Rezervation>, IRezervationDal
{
    public List<Rezervation> GetListWithRezervationByWaitAppRoval(int id)
    {
        using (var context = new Context())
        {
            return context.Rezervations.Include(x=>x.Destination).
                Where(x=>x.Status == "Onay Bekliyor" && x.AppUserId == id)
                .ToList();
        }
    }

    public List<Rezervation> GetListWithRezervationByAccepted(int id)
    {
        using (var context = new Context())
        {
            return context.Rezervations.Include(x=>x.Destination).
                Where(x=>x.Status == "Onaylandı" && x.AppUserId == id)
                .ToList();
        }
    }

    public List<Rezervation> GetListWithRezervationByPrevius(int id)
    {
        using (var context = new Context())
        {
            return context.Rezervations.Include(x=>x.Destination).
                Where(x=>x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id)
                .ToList();
        }
    }
}