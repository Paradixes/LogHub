using Client.Validations;
using Client.ViewModel;
using MudBlazor;

namespace Client.Features.Users.Login;

public partial class Index
{
    private readonly LoginModelValidator _validator = new();

    private MudForm _form = new();

    private bool _isInvalidateCredentials;

    private bool _isShow;

    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    private InputType _passwordInputType = InputType.Password;

    private LoginModel Model { get; } = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();
        if (!_form.IsValid)
        {
            return;
        }

        if (!await AuthenticationService.LogInAsync(Model))
        {
            _isInvalidateCredentials = true;
            return;
        }

        NavigationManager.NavigateTo("/");
    }

    private void PasswordStatusChanged()
    {
        _passwordInputIcon = _isShow ? Icons.Material.Filled.VisibilityOff : Icons.Material.Filled.Visibility;
        _passwordInputType = _isShow ? InputType.Password : InputType.Text;
        _isShow = !_isShow;
    }
}