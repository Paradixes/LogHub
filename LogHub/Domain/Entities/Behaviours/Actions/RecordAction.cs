using Domain.Entities.Records;
using Domain.Entities.Users;
using Domain.Primitives;

namespace Domain.Entities.Behaviours.Actions;

public class RecordAction : Entity<RecordActionId>
{
    protected RecordAction() { }

    internal RecordAction(
        RecordId recordId,
        UserId initiatorId,
        string message)
    {
        RecordId = recordId;
        InitiatorId = initiatorId;
        Message = message;
    }

    public RecordId RecordId { get; private set; } = null!;

    public Record? Record { get; private set; }

    public UserId InitiatorId { get; private set; } = null!;

    public User? Initiator { get; private set; }

    public string Message { get; private set; } = null!;

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }
}
