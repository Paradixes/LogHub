using LogHub.Client.Validations;
using LogHub.Client.ViewModel;
using LogHub.Shared.Enums;
using MudBlazor;

namespace LogHub.Client.Features.Users.Register;

public partial class Index
{
    private readonly string[] _professions =
        { "Researcher", "Student", "Engineer", "Data Manager", "Expert Witness", "Other" };

    private readonly RegisterModelValidator _validator = new();

    private MudForm _form = new();

    private bool _isInvalidateCredentials;

    private bool _success;

    private RegisterModel Model { get; } = new();

    private async Task SubmitAsync()
    {
        await _form.Validate();
        if (!_form.IsValid)
        {
            return;
        }

        Model.UpdateRole();
        if (!await AuthenticationService.RegisterAsync(Model))
        {
            _isInvalidateCredentials = true;
            return;
        }

        if (Model.Role == UserRole.DataManager)
        {
            NavigationManager.NavigateTo("/organisations/create");
            return;
        }

        NavigationManager.NavigateTo("/");
    }
}
