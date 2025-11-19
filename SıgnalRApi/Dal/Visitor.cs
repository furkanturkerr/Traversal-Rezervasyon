namespace SıgnalRApi.Dal;

public enum ECity
{
    Edirne = 1,
    İstanbul = 2,
    Ankara = 3,
    Bursary = 4
}
public class Visitor
{
    public int VisitorId { get; set; }
    public ECity ECity { get; set; }
    public int CityVisitCount { get; set; }
    public DateTime VisitDate { get; set; }
}