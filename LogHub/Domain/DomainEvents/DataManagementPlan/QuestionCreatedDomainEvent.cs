using LogHub.Domain.Entities.DataManagementPlan;
using LogHub.Domain.Entities.User;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.DataManagementPlan;

public record QuestionCreatedDomainEvent(Guid Id, UserId CreatorId, QuestionId QuestionId) : DomainEvent(Id);
