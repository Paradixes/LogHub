using LogHub.Shared.Enums;

namespace LogHub.Client.ViewModel;

public class RegisterModel
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ConfirmPassword { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string Profession { get; set; } = string.Empty;

    public string? Orcid { get; set; }

    public void UpdateRole()
    {
        if (Profession == "Data Manager")
        {
            Role = UserRole.DataManager;
        }
        else
        {
            Role = UserRole.Recorder;
        }
    }
}
