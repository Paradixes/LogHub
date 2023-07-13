using LogHub.Domain.Entities.Users;

namespace LogHub.Domain.Primitives;

public interface IRecordEntity : IAuditableEntity
{
    UserId CreatorId { get; }

    string Title { get; }

    string? Icon { get; }

    string? Description { get; }

    DateTime CreatedOnUtc { get; set; }

    DateTime? ModifiedOnUtc { get; set; }
}