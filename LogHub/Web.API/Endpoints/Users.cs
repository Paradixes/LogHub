﻿using Carter;
using LogHub.Application.Users.GetUserById;
using LogHub.Application.Users.Login;
using LogHub.Application.Users.Register;
using LogHub.Application.Users.Update;
using LogHub.Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogHub.Web.API.Endpoints;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users", async (
            [FromBody] RegisterUserRequest request,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new RegisterUserCommand(
                request.Email,
                request.Name,
                request.Profession,
                request.Orcid,
                request.Role,
                request.Password);

            var tokenResult = await sender.Send(
                command,
                cancellationToken);

            return tokenResult.IsFailure ? Results.BadRequest(tokenResult.Error) : Results.Ok(tokenResult.Value);
        });

        app.MapPost("api/login", async (
            [FromBody] LoginUserRequest request,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new LoginUserCommand(request.Email, request.Password);

            var tokenResult = await sender.Send(
                command,
                cancellationToken);

            return tokenResult.IsFailure ? Results.BadRequest(tokenResult.Error) : Results.Ok(tokenResult.Value);
        });

        app.MapGet("api/users/{id:guid}", async (
            Guid id,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var query = new GetUserByIdQuery(id);

            var response = await sender.Send(query, cancellationToken);

            return response.IsSuccess ? Results.Ok(response.Value) : Results.NotFound(response.Error);
        });

        app.MapPut("api/users/{id:guid}", async (
            Guid id,
            [FromBody] UpdateUserRequest request,
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new UpdateUserCommand(
                new UserId(id),
                request.Name,
                request.Avatar,
                request.Profession,
                request.Orcid);

            var result = await sender.Send(command, cancellationToken);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok();
        });
    }
}