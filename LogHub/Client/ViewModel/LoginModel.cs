using System.ComponentModel.DataAnnotations;

namespace LogHub.Client.ViewModel;

public class LoginModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
