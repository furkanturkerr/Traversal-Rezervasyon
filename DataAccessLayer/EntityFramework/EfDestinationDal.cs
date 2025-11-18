using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDestinationDal :  GenericRepository<Destination>, IDestinationDal
{
    public List<Destination> GetListWithGuide(int id)
    {
        using (var c = new Context())
        {
            return c.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).ToList();
        }
    }
}