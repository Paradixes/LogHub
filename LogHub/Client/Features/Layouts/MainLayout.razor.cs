using LogHub.Client.ViewModel;

namespace LogHub.Client.Features.Layouts;

public partial class MainLayout
{
    private bool _drawerOpen;

    protected UserModel? User { get; private set; }

    private void DrawerToggle(bool isDrawerOpen)
    {
        _drawerOpen = isDrawerOpen;
    }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var claims = authState.User.Identities.FirstOrDefault()?.Claims;
        if (claims != null)
        {
            User = UserModel.Create(claims);
        }
    }
}