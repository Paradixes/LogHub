using Carter;
using LogHub.Application.Users.Login;
using LogHub.Application.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogHub.Web.API.Endpoints;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users/register", async (
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

        app.MapPost("api/users/login", async (
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
    }
}
