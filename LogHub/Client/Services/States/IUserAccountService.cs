using Client.ViewModel;

namespace Client.Services.States;

public interface IUserAccountService
{
    UserAccountModel? CurrentUser { get; }

    SystemSettingsModel CurrentSystemSettings { get; }

    event Action OnChange;

    Task UpdateCurrentUserAsync();

    Task UpdateCurrentSystemSettingsAsync();

    bool IsLoggedIn();
}
