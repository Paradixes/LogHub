using LogHub.Domain.Entities.Actions;

namespace LogHub.Domain.Entities.Bases;

public record BaseActionId(Guid Value) : RecordActionId(Value);