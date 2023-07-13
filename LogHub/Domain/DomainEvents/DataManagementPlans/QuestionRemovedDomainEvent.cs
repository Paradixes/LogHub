using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record QuestionRemovedDomainEvent
    (Guid Id, DataManagementPlanId DataManagementPlanId, QuestionId QuestionId) : DomainEvent(Id);