using LogHub.Domain.Entities.Users;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Requests;

public class RecordRequest : Entity<RecordRequestId>, IAuditableEntity
{
    private RecordRequest() { }

    internal RecordRequest(
        RecordId recordId,
        UserId initiatorId,
        UserId handlerId,
        RecordType recordType,
        string message)
    {
        RecordId = recordId;
        InitiatorId = initiatorId;
        HandlerId = handlerId;
        RecordType = recordType;
        Message = message;
    }

    public UserId InitiatorId { get; private set; } = null!;

    public string Message { get; private set; } = null!;

    public RecordType RecordType { get; private set; }

    public RecordId RecordId { get; private set; } = null!;

    public UserId HandlerId { get; private set; } = null!;

    public RequestStatus Status { get; private set; }

    public DateTime CreatedOnUtc { get; set; }

    public DateTime? ModifiedOnUtc { get; set; }

    public void Approve()
    {
        if (Status != RequestStatus.WaitingForApproval)
        {
            throw new InvalidOperationException("Cannot accept a request that is not waiting for approval.");
        }

        Status = RequestStatus.Approved;
    }

    public void Reject()
    {
        if (Status != RequestStatus.WaitingForApproval)
        {
            throw new InvalidOperationException("Cannot reject a request that is not waiting for approval.");
        }

        Status = RequestStatus.Rejected;
    }
}
