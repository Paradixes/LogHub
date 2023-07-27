using LogHub.Client.ViewModel;

namespace LogHub.Client.Services.Authentications;

public interface ILogHubAuthenticationService
{
    Task<bool> LogInAsync(LoginViewModel model);

    Task LogOutAsync();
}
