using Domain.Primitives;

namespace Domain.Entities.Bases;

public record BaseId(Guid Value) : RecordId(Value);