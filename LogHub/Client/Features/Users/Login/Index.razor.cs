using LogHub.Client.Services.Authentications;
using LogHub.Client.ViewModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LogHub.Client.Features.Users.Login;

public partial class Index
{
    private MudForm _form = new();

    private bool _isShow;

    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    private InputType _passwordInputType = InputType.Password;

    [Inject] private IAuthenticationService _authenticationService { get; set; }

    [Inject] private NavigationManager _navigationManager { get; set; }

    private LoginViewModel Model { get; } = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();
        if (_form.IsValid)
        {
            await _authenticationService.LogInAsync(Model);
            _navigationManager.NavigateTo("/");
        }
    }

    private void PasswordStatusChanged()
    {
        _passwordInputIcon = _isShow ? Icons.Material.Filled.VisibilityOff : Icons.Material.Filled.Visibility;
        _passwordInputType = _isShow ? InputType.Password : InputType.Text;
        _isShow = !_isShow;
    }
}
