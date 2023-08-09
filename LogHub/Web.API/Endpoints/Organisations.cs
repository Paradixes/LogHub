using Application.Organisations.Create;
using Application.Organisations.GetById;
using Application.Organisations.GetByInvitationCode;
using Application.Organisations.GetSubOrganisations;
using Application.Organisations.GetUsers;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
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
            CancellationToken cancellationToken,
            ISender sender) =>
        {
            var command = new CreateOrganisationCommand(
                new UserId(request.ManagerId),
                request.Logo,
                request.Name,
                request.Description,
                request.ParentId?.Create<OrganisationId>());

            var result = await sender.Send(
                command,
                cancellationToken);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{id:guid}", async (Guid id, ISender sender) =>
        {
            var query = new GetOrganisationByIdQuery(new OrganisationId(id));

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{id:guid}/sub-organisations", async (Guid id, ISender sender) =>
        {
            var query = new GetSubOrganisationsQuery(new OrganisationId(id));

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{id:guid}/users", async (Guid id, ISender sender) =>
        {
            var query = new GetUsersByOrganisationQuery(new OrganisationId(id));

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{code}/invitation", async (string code, ISender sender) =>
        {
            var query = new GetOrganisationByInvitationCodeQuery(code);

            var result = await sender.Send(query);

            return result.IsFailure ? Results.Ok() : Results.Ok(result.Value);
        });
    }
}
