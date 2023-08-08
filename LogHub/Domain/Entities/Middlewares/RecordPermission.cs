using Domain.Entities.Records;
using Domain.Entities.Users;
using Shared.Enums;

namespace Domain.Entities.Middlewares;

public class RecordPermission
{
    private RecordPermission() { }

    internal RecordPermission(
        UserId userId,
        RecordId recordId,
        PermissionLevel level)
    {
        UserId = userId;
        RecordId = recordId;
        Level = level;
    }

    public UserId UserId { get; set; } = null!;

    public RecordId RecordId { get; private init; } = null!;

    public PermissionLevel Level { get; set; }

    public void UpdateLevel(PermissionLevel level)
    {
        Level = level;
    }
}
