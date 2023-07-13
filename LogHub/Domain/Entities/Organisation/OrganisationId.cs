using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Organisation;

public record OrganisationId(Guid Value) : EntityId(Value);