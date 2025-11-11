using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IGuideDal : IGenericDal<Guide>
{
    void ChangetoTrueByGuide(int id);
    void ChangetoFalseByGuide(int id);
}