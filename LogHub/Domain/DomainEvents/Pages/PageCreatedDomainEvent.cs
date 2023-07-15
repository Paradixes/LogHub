using LogHub.Domain.Entities.Pages;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Primitives;

namespace LogHub.Domain.DomainEvents.Pages;

public record PageCreatedDomainEvent(Guid Id, PageId PageId, UserId PageCreatorId) : DomainEvent(Id);