using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record QuestionAddedDomainEvent
    (Guid Id, DataManagementPlanId DataManagementPlanId, QuestionId QuestionId) : DomainEvent(Id);