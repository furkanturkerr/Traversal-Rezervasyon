using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Commend
{
    [Key]
    public int CommendId { get; set; }
    public string CommendUser { get; set; }
    public string CommendContent { get; set; }
    public DateTime CommendDate { get; set; }
    public string CommendState { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}