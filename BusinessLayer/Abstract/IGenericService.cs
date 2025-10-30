using DataAccessLayer.Abstract;

namespace BusinessLayer.Abstract;

public interface IGenericService<T>
{
    void Add(T t);
    void Delete(T t);
    void Edit(T t);
    List<T> GetAll();
    T GetById(int id);
}