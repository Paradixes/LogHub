using Client.ViewModel;
using Shared.Enums;

namespace Client.Services.States;

public interface IOrganisationPermissionService
{
    public List<OrganisationSettingsModel> OrganisationPermissions { get; }

    event Action OnChange;

    Task UpdateAsync(Guid id);

    OrganisationRole GetRole(OrganisationOption option);
}
