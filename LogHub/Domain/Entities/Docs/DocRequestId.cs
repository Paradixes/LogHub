using Domain.Entities.Requests;

namespace Domain.Entities.Docs;

public record DocRequestId(Guid Value) : RecordRequestId(Value);