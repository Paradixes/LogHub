using Domain.Primitives;

namespace Domain.Entities.Organisations;

public record OrganisationId(Guid Value) : EntityId(Value);