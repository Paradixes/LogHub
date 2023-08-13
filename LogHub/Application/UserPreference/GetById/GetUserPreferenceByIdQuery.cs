﻿using Domain.Entities.Users;
using MediatR;

namespace Application.UserPreference.GetById;

public sealed record GetUserPreferenceByIdQuery(UserId UserId) : IRequest<UserPreferenceResponse>;
