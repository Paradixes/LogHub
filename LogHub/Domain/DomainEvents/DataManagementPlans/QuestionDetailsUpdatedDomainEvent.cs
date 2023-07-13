using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record QuestionDetailsUpdatedDomainEvent(Guid Id, QuestionId QuestionId) : DomainEvent(Id);