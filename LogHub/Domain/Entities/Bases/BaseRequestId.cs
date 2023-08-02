using Domain.Entities.Requests;

namespace Domain.Entities.Bases;

public record BaseRequestId(Guid Value) : RecordRequestId(Value);