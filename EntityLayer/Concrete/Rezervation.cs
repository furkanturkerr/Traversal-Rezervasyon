namespace EntityLayer.Concrete;

public class Rezervation
{
    public int RezervationId { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int PersonCount { get; set; }
    public string Destination { get; set; }
    public DateTime RezervassyonDate { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public List<Rezervation> RezervationS { get; set; } 
}