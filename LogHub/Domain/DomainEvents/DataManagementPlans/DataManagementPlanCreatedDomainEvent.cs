using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record DataManagementPlanCreatedDomainEvent
    (Guid Id, UserId UserId, DataManagementPlanId DataManagementPlanId) : DomainEvent(Id);