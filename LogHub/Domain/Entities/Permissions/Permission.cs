using LogHub.Domain.DomainEvents.Permissions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permissions;

public class Permission : Entity<PermissionId>
{
    private Permission() { }

    public Permission(UserId userId, RecordId recordId, RecordType recordType, Permission type)
    {
        UserId = userId;
        RecordId = recordId;
        RecordType = recordType;
        Type = type;
    }

    public UserId UserId { get; private set; }
    public RecordId RecordId { get; private set; }
    public RecordType RecordType { get; private set; }
    public Permission Type { get; private set; }

    public static Permission Create(UserId userId, RecordId recordId, RecordType recordType, Permission type)
    {
        var permission = new Permission
        {
            Id = new PermissionId(Guid.NewGuid()),
            UserId = userId,
            RecordId = recordId,
            RecordType = recordType,
            Type = type
        };

        permission.Raise(new PermissionCreatedDomainEvent(
            Guid.NewGuid(),
            permission.Id,
            permission.UserId,
            permission.RecordId,
            permission.RecordType,
            permission.Type));

        return permission;
    }

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
