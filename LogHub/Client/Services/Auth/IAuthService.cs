using LogHub.Shared.ViewModel;

namespace LogHub.Client.Services.Auth
{
    public interface IAuthService
    {
        Task SignInAsync(LoginViewModel model);

        Task SignOutAsync();
    }
}
