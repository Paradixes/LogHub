using LogHub.Client.Services.Auth;
using LogHub.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LogHub.Client.Pages;

public partial class Login
{
    private MudForm Form = new();
    LoginViewModel Model { get; set; } = new();

    [Inject] IAuthService AuthService { get; set; }

    [Inject] NavigationManager NavigationManager { get; set; }

    private async Task SubmitAsync()
    {
        await Form.Validate();
        if (Form.IsValid)
        {
            try
            {
                await AuthService.LogInAsync(Model);
                NavigationManager.NavigateTo("/");
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }
    }

    bool isShow = false;
    string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
    InputType PasswordInputType = InputType.Password;

    void PasswordStatusChanged()
    {
        PasswordInputIcon = isShow ? Icons.Material.Filled.VisibilityOff : Icons.Material.Filled.Visibility;
        PasswordInputType = isShow ? InputType.Password : InputType.Text;
        isShow = !isShow;
    }
}
