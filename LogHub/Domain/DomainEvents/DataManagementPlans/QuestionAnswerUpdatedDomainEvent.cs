using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record QuestionAnswerUpdatedDomainEvent(Guid Id, QuestionId QuestionId) : DomainEvent(Id);