using System.ComponentModel.DataAnnotations;

namespace Traversal_Rezervasyon.Models;

public class UserRegisterViewModel
{
    [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
    public string SurName { get; set; }
    
    [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Lütfen Mail adresinizi giriniz.")]
    public string Mail { get; set; }
    
    [Required(ErrorMessage = "Lütfen şifreyi giriniz.")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string ConfirmPassword { get; set; }
}