using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Feature
{
    [Key]
    public int FeatureId { get; set; }
    public string Post1Name { get; set; }
    public string PostDescription{ get; set; }
    public string Post1Image{ get; set; }
    public bool Status { get; set; }
}