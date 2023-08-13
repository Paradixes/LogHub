using Domain.Entities.Events.Actions;

namespace Domain.Entities.Events.Requests;

public record RecordRequestId(Guid Value) : RecordActionId(Value);