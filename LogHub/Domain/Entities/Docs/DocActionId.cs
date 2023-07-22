using LogHub.Domain.Entities.Actions;

namespace LogHub.Domain.Entities.Docs;

public record DocActionId(Guid Value) : RecordActionId(Value);