using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisations;

public record OrganisationId(Guid Value) : EntityId(Value);