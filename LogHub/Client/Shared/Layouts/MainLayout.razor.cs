using LogHub.Client.ViewModel;
using MudBlazor;

namespace LogHub.Client.Shared.Layouts;

public partial class MainLayout
{
    private readonly MudTheme _theme = new();

    private bool _drawerOpen = true;

    private bool _isDarkMode;

    protected UserViewModel? User { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var claims = authState.User.Identities.FirstOrDefault()?.Claims;
        if (claims != null)
        {
            User = UserViewModel.Create(claims);
        }
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private async Task LogOutAsync()
    {
        await AuthenticationService.LogOutAsync();
        NavigationManager.NavigateTo("/");
    }
}
