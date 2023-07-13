using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record DataManagementPlanDetailsUpdatedDomainEvent
    (Guid Id, DataManagementPlanId DataManagementPlanId) : DomainEvent(Id);