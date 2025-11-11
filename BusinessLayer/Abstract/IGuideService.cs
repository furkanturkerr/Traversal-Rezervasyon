using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IGuideService :  IGenericService<Guide>
{
    void TChangetoTrueByGuide(int id);
    void TChangetoFalseByGuide(int id);
}