using System.Net;
using Client.Validations;
using Client.ViewModel;
using MudBlazor;
using Shared.Enums;

namespace Client.Features.Users.Register;

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
        var response = await AuthenticationService.RegisterAsync(Model);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            _isInvalidateCredentials = true;
            return;
        }

        if (Model.Role == UserRole.DataManager)
        {
            NavigationManager.NavigateTo("/organisations/create");
            return;
        }

        NavigationManager.NavigateTo("/organisations/join");
    }
}
