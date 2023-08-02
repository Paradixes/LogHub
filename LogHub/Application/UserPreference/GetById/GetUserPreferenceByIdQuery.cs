using Application.Abstracts.Messaging;

namespace Application.UserPreference.GetById;

public sealed record GetUserPreferenceByIdQuery(Guid UserId) : IQuery<UserPreferenceResponse>;