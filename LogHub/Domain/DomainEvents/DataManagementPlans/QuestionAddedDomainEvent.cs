using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record QuestionAddedDomainEvent
    (Guid Id, DataManagementPlanId DataManagementPlanId, QuestionId QuestionId) : DomainEvent(Id);