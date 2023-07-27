using LogHub.Client.ViewModel;

namespace LogHub.Client.Services.Authentications;

public interface ILogHubAuthenticationService
{
    Task LogInAsync(LoginViewModel model);

    Task LogOutAsync();
}