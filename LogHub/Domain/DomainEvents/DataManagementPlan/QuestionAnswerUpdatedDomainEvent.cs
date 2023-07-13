using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record QuestionAnswerUpdatedDomainEvent(Guid Id, QuestionId QuestionId) : DomainEvent(Id);
