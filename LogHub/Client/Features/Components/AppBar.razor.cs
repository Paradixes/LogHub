using LogHub.Client.ViewModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LogHub.Client.Features.Components;

public partial class AppBar
{
    private readonly MudTheme _theme = new();

    private bool _drawerOpen;

    private bool _isDarkMode;

    [Parameter] public EventCallback<bool> DrawerOpenChanged { get; set; }

    [Parameter] public UserModel? User { get; set; }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
        DrawerOpenChanged.InvokeAsync(_drawerOpen);
    }

    private async Task LogOutAsync()
    {
        await AuthenticationService.LogOutAsync();
        NavigationManager.NavigateTo("/");
    }
}