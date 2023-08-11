using Client.ViewModel;

namespace Client.Services.States;

public interface IUserAccountService
{
    UserAccountModel? CurrentUser { get; }

    event Action OnChange;

    Task UpdateCurrentUserAsync();

    bool IsLoggedIn();
}
