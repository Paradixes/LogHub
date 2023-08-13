using Client.ViewModel;

namespace Client.Services.Authentications;

public interface ILogHubAuthenticationService
{
    Task<HttpResponseMessage> LogInAsync(LoginModel model);

    Task LogOutAsync();

    Task<HttpResponseMessage> RegisterAsync(RegisterModel model);

    Task<Guid?> GetLocalUserIdAsync();
}
