using LogHub.Domain.Entities.Actions;

namespace LogHub.Domain.Entities.Requests;

public record RecordRequestId(Guid Value) : RecordActionId(Value);
