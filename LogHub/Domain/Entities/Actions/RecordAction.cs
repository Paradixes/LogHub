using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Actions;

public class RecordAction : Entity<RecordActionId>, IAuditableEntity
{
    private RecordAction() { }

    internal RecordAction(
        RecordId recordId,
        UserId initiatorId,
        RecordType recordType,
        string message)
    {
        RecordId = recordId;
        InitiatorId = initiatorId;
        RecordType = recordType;
        Message = message;
    }

    public RecordActionId Id { get; } = new(Guid.NewGuid());

    public RecordId RecordId { get; private set; } = null!;

    public UserId InitiatorId { get; private set; } = null!;

    public RecordType RecordType { get; private set; }

    public string Message { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}
