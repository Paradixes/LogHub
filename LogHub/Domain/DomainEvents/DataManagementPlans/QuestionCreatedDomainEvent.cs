using LogHub.Domain.Entities.DataManagementPlans;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlans;

public record QuestionCreatedDomainEvent(Guid Id, UserId CreatorId, QuestionId QuestionId) : DomainEvent(Id);