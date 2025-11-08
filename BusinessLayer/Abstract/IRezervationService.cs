using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IRezervationService : IGenericService<Rezervation>
{
    List<Rezervation> GetListWithRezervationByWaitAppRoval(int id);
    List<Rezervation> GetListWithRezervationByPrevius(int id);
    List<Rezervation> GetListWithRezervationByAccepted(int id);
}