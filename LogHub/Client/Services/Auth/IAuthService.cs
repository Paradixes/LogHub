using LogHub.Shared.ViewModel;

namespace LogHub.Client.Services.Auth
{
    public interface IAuthService
    {
        Task LogInAsync(LoginViewModel model);

        Task LogOutAsync();
    }
}
