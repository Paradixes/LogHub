using LogHub.Domain.Entities.User;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Permission;

public class Permission : Entity<PermissionId>
{
    private Permission() { }

    public Permission(UserId userId, RecordId recordId, DocumentType documentType, Permission type)
    {
        UserId = userId;
        RecordId = recordId;
        DocumentType = documentType;
        Type = type;
    }

    public UserId UserId { get; private set; }
    public RecordId RecordId { get; private set; }
    public DocumentType DocumentType { get; private set; }
    public Permission Type { get; private set; }
}