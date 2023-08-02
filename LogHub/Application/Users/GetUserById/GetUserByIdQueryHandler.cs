﻿using LogHub.Application.Abstracts.Messaging;
using LogHub.Domain.Entities.Users;
using LogHub.Domain.Repositories;
using LogHub.Domain.Shared;

namespace LogHub.Application.Users.GetUserById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResponse>> Handle(
        GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(new UserId(query.UserId), cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(new Error(
                "User.NotFound",
                $"The user with Id {query.UserId} was not found"));
        }

        var response = new UserResponse(
            user.Id.Value,
            user.Email,
            user.Name,
            user.AvatarUri,
            user.OrganisationId?.Value,
            user.DepartmentId?.Value,
            user.Profession,
            user.Orcid,
            user.Role
        );

        return response;
    }
}