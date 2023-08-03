using Domain.Entities.Users;
using Domain.Primitives;

namespace Domain.Entities.Actions;

public class RecordAction<TId, TRecordId> : Entity<TId>, IAuditableEntity
    where TId : RecordActionId
    where TRecordId : RecordId
{
    protected RecordAction() { }

    internal RecordAction(
        TRecordId recordId,
        UserId initiatorId,
        string message)
    {
        RecordId = recordId;
        InitiatorId = initiatorId;
        Message = message;
    }

    public TRecordId RecordId { get; private set; } = null!;

    public UserId InitiatorId { get; private set; } = null!;

    public string Message { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}