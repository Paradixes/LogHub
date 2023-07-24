using Carter;
using LogHub.Application.Users.Login;
using LogHub.Application.Users.Register;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Enums;
using LogHub.Domain.Primitives;
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
                request.OrganisationId?.Create<OrganisationId>()!,
                request.DepartmentId?.Create<DepartmentId>()!,
                request.Profession,
                request.Orcid,
                (UserRole)Enum.Parse(typeof(UserRole), request.Role),
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
