using Application.Memberships.Delete;
using Application.Memberships.GetById;
using Application.Memberships.GetSubOrganisations;
using Application.Memberships.GetUsers;
using Application.Memberships.JoinByInvitationCode;
using Application.Memberships.Update;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Exceptions.Memberships;
using Domain.Exceptions.Organisations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace Web.API.Endpoints;

public class Memberships : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/organisations/{organisationId:guid}/users/{userId:guid}", async (
            Guid organisationId,
            Guid userId,
            ISender sender) =>
        {
            try
            {
                var query = new GetMembershipByIdQuery(new UserId(userId), new OrganisationId(organisationId));
                return Results.Ok(await sender.Send(query));
            }
            catch (MembershipNotFoundException e)
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

        app.MapPut("api/organisations/{organisationId:guid}/users/{userId:guid}", async (
            Guid organisationId,
            Guid userId,
            [FromBody] OrganisationRole role,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateMembershipCommand(
                    new UserId(userId),
                    new OrganisationId(organisationId),
                    role);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (MembershipNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("api/organisations/{organisationId:guid}/users/{userId:guid}", async (
            Guid organisationId,
            Guid userId,
            ISender sender) =>
        {
            try
            {
                var command = new DeleteMembershipCommand(
                    new UserId(userId),
                    new OrganisationId(organisationId));

                await sender.Send(command);

                return Results.Ok();
            }
            catch (MembershipNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
