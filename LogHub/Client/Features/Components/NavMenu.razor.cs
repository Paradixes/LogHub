using LogHub.Client.ViewModel;
using Microsoft.AspNetCore.Components;

namespace LogHub.Client.Features.Components;

public partial class NavMenu
{
    [Parameter] public bool DrawerOpen { get; set; }

    [Parameter] public UserModel? User { get; set; }

    private void DrawerToggle(bool isDrawerOpen)
    {
        DrawerOpen = isDrawerOpen;
    }

    private async Task LogOutAsync()
    {
        await AuthenticationService.LogOutAsync();
        NavigationManager.NavigateTo("/");
        DrawerOpen = false;
        StateHasChanged();
    }
}