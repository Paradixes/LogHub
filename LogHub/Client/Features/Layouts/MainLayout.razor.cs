using LogHub.Client.ViewModel;

namespace LogHub.Client.Features.Layouts;

public partial class MainLayout
{
    private bool _drawerOpen;


    private void DrawerToggle(bool isDrawerOpen)
    {
        _drawerOpen = isDrawerOpen;
    }
}
