using LogHub.Domain.Primitives;

namespace LogHub.Domain.Entities.Pages;

public record FavouritePageId(Guid Value) : EntityId(Value);