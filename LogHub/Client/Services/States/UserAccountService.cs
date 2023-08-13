using System.Net.Http.Json;
using Client.Services.Authentications;
using Client.ViewModel;

namespace Client.Services.States;

public class UserAccountService : IUserAccountService
{
    private readonly ILogHubAuthenticationService _authenticationService;
    private readonly HttpClient _client;

    public UserAccountService(
        HttpClient client,
        ILogHubAuthenticationService authenticationService)
    {
        _client = client;
        _authenticationService = authenticationService;
    }

    public UserAccountModel? CurrentUser { get; private set; }
    public SystemSettingsModel CurrentSystemSettings { get; private set; } = new();

    public event Action? OnChange;

    public async Task UpdateCurrentUserAsync()
    {
        var userId = await _authenticationService.GetLocalUserIdAsync();
        if (userId is null)
        {
            CurrentUser = null;
            NotifyStateChanged();
            return;
        }

        var response = await _client.GetAsync($"api/users/{userId}");
        if (!response.IsSuccessStatusCode)
        {
            CurrentUser = null;
            NotifyStateChanged();
            return;
        }

        CurrentUser = await response.Content.ReadFromJsonAsync<UserAccountModel>();
        await UpdateCurrentSystemSettingsAsync();
        NotifyStateChanged();
    }

    public async Task UpdateCurrentSystemSettingsAsync()
    {
        if (CurrentUser is null)
        {
            return;
        }

        CurrentSystemSettings =
            await _client.GetFromJsonAsync<SystemSettingsModel>($"api/users/{CurrentUser.Id}/preference") ??
            new SystemSettingsModel();
        NotifyStateChanged();
    }

    public bool IsLoggedIn()
    {
        return CurrentUser is not null;
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
