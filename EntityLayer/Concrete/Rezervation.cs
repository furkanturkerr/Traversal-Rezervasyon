using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Rezervation
{
    [Key]
    public int RezervationId { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int PersonCount { get; set; }
    public DateTime RezervassyonDate { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
}