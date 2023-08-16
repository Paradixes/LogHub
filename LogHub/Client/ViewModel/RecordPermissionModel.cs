using Shared.Enums;

namespace Client.ViewModel;

public class RecordPermissionModel
{
    public Guid RecordId { get; set; }

    public Guid UserId { get; set; }

    public UserAccountModel User { get; set; } = new();

    public PermissionLevel Level { get; set; } = PermissionLevel.NotAuthorized;
}
