using System.Net.Http.Json;
using Client.ViewModel;
using Shared.Enums;

namespace Client.Services.States;

public class OrganisationPermissionService : IOrganisationPermissionService
{
    private readonly HttpClient _client;

    public OrganisationPermissionService(HttpClient client)
    {
        _client = client;
    }

    public List<OrganisationSettingsModel> OrganisationPermissions { get; private set; } = new();

    public event Action? OnChange;

    public async Task UpdateAsync(Guid id)
    {
        OrganisationPermissions =
            await _client.GetFromJsonAsync<List<OrganisationSettingsModel>>($"api/organisations/{id}/settings")
            ?? new List<OrganisationSettingsModel>();

        NotifyStateChanged();
    }

    public OrganisationRole GetRole(OrganisationOption option)
    {
        var permission = OrganisationPermissions.FirstOrDefault(x => x.Option == option);
        return permission?.Role ?? OrganisationRole.Owner;
    }

    private void NotifyStateChanged()
    {
        OnChange?.Invoke();
    }
}
