using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permissions;

public class Permission : Entity<PermissionId>
{
    private Permission() { }

    internal Permission(
        UserId userId,
        RecordId recordId,
        RecordType recordType,
        PermissionLevel level)
    {
        UserId = userId;
        RecordId = recordId;
        RecordType = recordType;
        Level = level;
    }

    public UserId UserId { get; set; } = null!;

    public RecordId RecordId { get; private init; } = null!;

    public RecordType RecordType { get; private init; }

    public PermissionLevel Level { get; set; }

    public void UpdateLevel(PermissionLevel level)
    {
        Level = level;
    }
}
