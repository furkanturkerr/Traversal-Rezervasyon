using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CommandManager : ICommandService
{
    private readonly ICommandDal _commandDal;

    public CommandManager(ICommandDal commandDal)
    {
        _commandDal = commandDal;
    }
    public void Add(Commend t)
    {
        throw new NotImplementedException();
    }

    public void Delete(Commend t)
    {
        throw new NotImplementedException();
    }

    public void Edit(Commend t)
    {
        throw new NotImplementedException();
    }

    public List<Commend> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<Commend> TGetDestinationBYıD(int id)
    {
        return _commandDal.GetListByFilter(x => x.DestinationId == id);
    }

    public Commend GetById(int id)
    {
        throw new NotImplementedException();
    }
}