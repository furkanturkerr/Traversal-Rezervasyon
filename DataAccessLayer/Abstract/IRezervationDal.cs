using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IRezervationDal : IGenericDal<Rezervation>
{
    List<Rezervation> GetListWithRezervationByWaitAppRoval(int id);
    List<Rezervation> GetListWithRezervationByAccepted(int id);
    List<Rezervation> GetListWithRezervationByPrevius(int id);
}