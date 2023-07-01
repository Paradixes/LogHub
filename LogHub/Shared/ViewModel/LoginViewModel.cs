using System.ComponentModel.DataAnnotations;

namespace LogHub.Shared.ViewModel;

public class LoginViewModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "The email address is invalid")]
    public string? Email { get; set; }

    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}
