using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record DataManagementPlanDetailsUpdatedDomainEvent
    (Guid Id, DataManagementPlanId DataManagementPlanId) : DomainEvent(Id);
