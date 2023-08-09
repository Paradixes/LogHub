using Domain.Entities.Behaviours.Actions;

namespace Domain.Entities.Behaviours.Requests;

public record RecordRequestId(Guid Value) : RecordActionId(Value);