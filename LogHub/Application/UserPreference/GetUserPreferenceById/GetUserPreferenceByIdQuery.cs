using LogHub.Application.Abstracts.Messaging;

namespace LogHub.Application.UserPreference.GetUserPreferenceById;

public sealed record GetUserPreferenceByIdQuery(Guid UserId) : IQuery<UserPreferenceResponse>;