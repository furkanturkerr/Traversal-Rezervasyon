using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Testimonial
{
    [Key]
    public int TestimonialId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Comment { get; set; }
    public string ClientImage { get; set; }
    public bool Status { get; set; }
}