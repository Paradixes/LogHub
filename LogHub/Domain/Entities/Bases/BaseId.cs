using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Bases;

public record BaseId(Guid Value) : RecordId(Value);