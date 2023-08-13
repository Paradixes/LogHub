using Application.Users.GetById;
using Application.Users.GetOrganisations;
using Application.Users.GetRootOrganisations;
using Application.Users.Login;
using Application.Users.Register;
using Application.Users.Update;
using Carter;
using Domain.Entities.Users;
using Domain.Exceptions.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/users", async (
            [FromBody] RegisterUserRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new RegisterUserCommand(
                    request.Email,
                    request.Name,
                    request.Profession,
                    request.Orcid,
                    request.Role,
                    request.Password);
                return Results.Ok(await sender.Send(command));
            }
            catch (UserEmailNotUniqueException e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        app.MapPost("api/login", async (
            [FromBody] LoginUserRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new LoginUserCommand(request.Email, request.Password);
                return Results.Ok(await sender.Send(command));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (InvalidCredentialsException e)
            {
                return Results.BadRequest(e.Message);
            }
        });

        app.MapGet("api/users/{id:guid}", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetUserByIdQuery(new UserId(id));
                return Results.Ok(await sender.Send(query));
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("api/users/{id:guid}", async (
            Guid id,
            [FromBody] UpdateUserRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateUserCommand(
                    new UserId(id),
                    request.Name,
                    request.Avatar,
                    request.Profession,
                    request.Orcid);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("api/users/{id:guid}/root-organisations", async (Guid id, ISender sender) =>
        {
            var query = new GetRootOrganisationsByIdQuery(id);

            return Results.Ok(await sender.Send(query));
        });

        app.MapGet("api/users/{id:guid}/organisations", async (Guid id, ISender sender) =>
        {
            var query = new GetOrganisationsByUserIdQuery(id);

            return Results.Ok(await sender.Send(query));
        });
    }
}
