using System.ComponentModel.DataAnnotations;

namespace Traversal_Rezervasyon.Models;

public class SıgnViewModel
{
    [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
    public string Password { get; set; }
}