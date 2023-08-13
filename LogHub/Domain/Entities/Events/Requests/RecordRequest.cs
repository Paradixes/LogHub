using Domain.Entities.Records;
using Domain.Entities.Users;
using Domain.Primitives;
using Shared.Enums;

namespace Domain.Entities.Events.Requests;

public class RecordRequest : Entity<RecordRequestId>
{
    private RecordRequest() { }

    internal RecordRequest(
        RecordId recordId,
        RecordRequestCommand command,
        UserId initiatorId,
        UserId handlerId,
        string message)
    {
        RecordId = recordId;
        HandlerId = handlerId;
        InitiatorId = initiatorId;
        Status = RequestStatus.WaitingForApproval;
        Command = command;
        Message = message;
    }

    public RecordId RecordId { get; private set; } = null!;

    public Record? Record { get; private set; }

    public UserId InitiatorId { get; private set; } = null!;

    public User? Initiator { get; private set; }

    public UserId HandlerId { get; private set; } = null!;

    public User? Handler { get; private set; }

    public RequestStatus Status { get; private set; }

    public RecordRequestCommand Command { get; private set; }

    public string Message { get; private set; } = null!;

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