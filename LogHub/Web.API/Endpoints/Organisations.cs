using Application.Organisations.Create;
using Application.Organisations.Delete;
using Application.Organisations.GetById;
using Application.Organisations.GetByInvitationCode;
using Application.Organisations.GetSubOrganisations;
using Application.Organisations.GetUsers;
using Application.Organisations.JoinByInvitationCode;
using Application.Organisations.Update;
using Application.Organisations.UpdateInvitationCode;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Exceptions.Organisations;
using Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Organisations : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/organisations", async (
            [FromBody] CreateOrganisationRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new CreateOrganisationCommand(
                    new UserId(request.OwnerId),
                    request.Logo,
                    request.Name,
                    request.Description,
                    request.ParentId?.Create<OrganisationId>());

                await sender.Send(command);

                return Results.Ok();
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("api/organisations/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                var query = new GetOrganisationByIdQuery(new OrganisationId(id));
                return Results.Ok(await sender.Send(query));
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("api/organisations/{id:guid}/sub-organisations", async (Guid id, ISender sender) =>
        {
            var query = new GetSubOrganisationsQuery(new OrganisationId(id));

            return Results.Ok(await sender.Send(query));
        });

        app.MapGet("api/organisations/{id:guid}/users", async (Guid id, ISender sender) =>
        {
            var query = new GetUsersByOrganisationQuery(new OrganisationId(id));

            return Results.Ok(await sender.Send(query));
        });

        app.MapGet("api/organisations/{code}/invitation", async (string code, ISender sender) =>
        {
            try
            {
                var query = new GetOrganisationByInvitationCodeQuery(code);

                return Results.Ok(await sender.Send(query));
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPost("api/organisations/{code}/invitation", async (
            [FromBody] Guid userId,
            string code,
            ISender sender) =>
        {
            try
            {
                var command = new JoinOrganisationByInvitationCodeCommand(new UserId(userId), code);
                await sender.Send(command);

                return Results.Ok();
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("api/organisations/{id:guid}", async (
            [FromBody] UpdateOrganisationRequest request,
            Guid id,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateOrganisationCommand(
                    new OrganisationId(id),
                    request.Name,
                    request.Logo,
                    request.Description,
                    request.OwnerId?.Create<UserId>());

                await sender.Send(command);

                return Results.Ok();
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("api/organisations/{id:guid}/invitation", async (
            [FromBody] string invitationCode,
            Guid id,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateOrganisationInvitationCodeCommand(
                    new OrganisationId(id),
                    invitationCode);

                return Results.Ok(await sender.Send(command));
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("api/organisations/{id:guid}", async (Guid id, ISender sender) =>
        {
            try
            {
                var command = new DeleteOrganisationCommand(new OrganisationId(id));

                await sender.Send(command);

                return Results.Ok();
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
