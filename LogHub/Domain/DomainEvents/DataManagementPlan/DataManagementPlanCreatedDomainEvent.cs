using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record DataManagementPlanCreatedDomainEvent
    (Guid Id, UserId UserId, DataManagementPlanId DataManagementPlanId) : DomainEvent(Id);
