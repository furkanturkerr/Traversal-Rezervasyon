using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfCommendDal : GenericRepository<Commend>, ICommandDal
{
    public List<Commend> GetListCommandWithDestination()
    {
        using (var c = new Context())
        {
            return c.Commends.Include(x => x.Destination).ToList();
        }
    }

    public List<Commend> GetListCommandWithUserandDestination(int id)
    {
        using (var c = new Context())
        {
            return c.Commends.Where(x=>x.DestinationId==id).Include(x => x.AppUser).ToList();
        }
    }
}