using Domain.Entities.Users;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Permissions;

public class RecordPermission<TId, TRecordId> : Entity<TId>
    where TId : RecordPermissionId
    where TRecordId : RecordId
{
    private RecordPermission() { }

    internal RecordPermission(
        UserId userId,
        TRecordId recordId,
        PermissionLevel level)
    {
        UserId = userId;
        RecordId = recordId;
        Level = level;
    }

    public UserId UserId { get; set; } = null!;

    public TRecordId RecordId { get; private init; } = null!;

    public PermissionLevel Level { get; set; }

    public void UpdateLevel(PermissionLevel level)
    {
        Level = level;
    }
}