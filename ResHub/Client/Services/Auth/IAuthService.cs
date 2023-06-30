using ResHub.Shared.ViewModel;

namespace ResHub.Client.Services.Auth
{
    public interface IAuthService
    {
        Task SignInAsync(LoginViewModel model);

        Task SignOutAsync();
    }
}
