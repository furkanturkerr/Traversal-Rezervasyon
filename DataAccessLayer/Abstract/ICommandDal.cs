using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface ICommandDal : IGenericDal<Commend>
{
    public List<Commend> GetListCommandWithDestination();
} 