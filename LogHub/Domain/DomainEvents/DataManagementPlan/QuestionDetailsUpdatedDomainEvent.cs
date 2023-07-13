using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record QuestionDetailsUpdatedDomainEvent(Guid Id, QuestionId QuestionId) : DomainEvent(Id);
