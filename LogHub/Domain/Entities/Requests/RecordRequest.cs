using LogHub.Domain.Entities.Actions;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;
using LogHub.Shared.Enums;

namespace LogHub.Domain.Entities.Requests;

public class RecordRequest<TId, TRecordId> : RecordAction<TId, TRecordId>
    where TId : RecordRequestId
    where TRecordId : RecordId
{
    private RecordRequest() { }

    internal RecordRequest(
        TRecordId recordId,
        UserId initiatorId,
        UserId handlerId,
        string message)
        : base(recordId, initiatorId, message)
    {
        HandlerId = handlerId;
        Status = RequestStatus.WaitingForApproval;
    }

    public UserId HandlerId { get; private set; } = null!;

    public RequestStatus Status { get; private set; }

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