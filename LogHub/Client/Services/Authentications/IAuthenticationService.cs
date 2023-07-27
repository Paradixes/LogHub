using LogHub.Client.ViewModel;

namespace LogHub.Client.Services.Authentications;

public interface IAuthenticationService
{
    Task LogInAsync(LoginViewModel model);

    Task LogOutAsync();
}
