using LogHub.Domain.Entities.Permissions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;
using Permission = LogHub.Domain.Entities.Permissions.Permission;

namespace LogHub.Domain.DomainEvents.Permissions;

public record PermissionUpdatedDomainEvent(Guid Id, PermissionId PermissionId, UserId UserId, RecordId RecordId,
    RecordType RecordType, Permission Type) : DomainEvent(Id);