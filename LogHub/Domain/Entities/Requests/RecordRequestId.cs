using Domain.Entities.Actions;

namespace Domain.Entities.Requests;

public record RecordRequestId(Guid Value) : RecordActionId(Value);