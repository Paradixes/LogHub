using LogHub.Domain.DomainEvents.Permissions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permissions;

public class Permission : Entity<PermissionId>
{
    private Permission() { }

    internal Permission(UserId userId, RecordId recordId, RecordType recordType, Permission type)
    {
        Id = new PermissionId(Guid.NewGuid());
        UserId = userId;
        RecordId = recordId;
        RecordType = recordType;
        Type = type;
    }

    public UserId UserId { get; }

    public RecordId RecordId { get; }

    public RecordType RecordType { get; }

    public Permission Type { get; private set; }

    public void UpdatePermission(Permission type)
    {
        if (Type == type)
        {
            return;
        }

        Type = type;
        Raise(new PermissionUpdatedDomainEvent(
            Guid.NewGuid(),
            Id,
            UserId,
            RecordId,
            RecordType,
            Type));
    }
}
