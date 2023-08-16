using Client.ViewModel;
using Shared.Enums;

namespace Client.Services.States;

public interface IRecordPermissionService
{
    public List<RecordPermissionModel> OrganisationPermissions { get; }

    event Action OnChange;

    Task UpdateAsync(Guid id);

    PermissionLevel GetRole(RecordRequestCommand command);
}
