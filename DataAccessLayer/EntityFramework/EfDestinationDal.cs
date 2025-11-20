using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDestinationDal :  GenericRepository<Destination>, IDestinationDal
{
    public Destination GetListWithGuide(int id)
    {
        using (var c = new Context())
        {
            return c.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).FirstOrDefault();
        }
    }

    public List<Destination> GetLast4Destinations()
    {
        using (var c = new Context())
        {
            var values = c.Destinations.Take(4).OrderByDescending(x => x.DestinationId).ToList();
            return values;
        }
    }
}