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
        _commandDal.Insert(t);
    }

    public void Delete(Commend t)
    {
        _commandDal.Delete(t);
    }

    public void Edit(Commend t)
    {
        _commandDal.Update(t);
    }

    public List<Commend> GetAll()
    {
        return _commandDal.GetList();
    }

    public List<Commend> TGetDestinationBYıD(int id)
    {
        return _commandDal.GetListByFilter(x => x.DestinationId == id);
    }

    public List<Commend> TGetListCommandWithDestination()
    {
        return _commandDal.GetListCommandWithDestination();
    }

    public Commend GetById(int id)
    {
        return _commandDal.GetById(id);
    }
}