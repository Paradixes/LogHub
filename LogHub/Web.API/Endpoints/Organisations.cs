using Carter;
using LogHub.Application.Organisations.AddDepartment;
using LogHub.Application.Organisations.Create;
using LogHub.Application.Organisations.GetOrganisationById;
using LogHub.Domain.Entities.Organisations;
using LogHub.Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogHub.Web.API.Endpoints;

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
                request.Description);

            var result = await sender.Send(
                command,
                cancellationToken);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{id:guid}", async (Guid id, ISender sender) =>
        {
            var query = new GetOrganisationByIdQuery(id);

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapPut("api/organisations/{id:guid}/departments", async (
            Guid id,
            [FromBody] AddDepartmentRequest request,
            ISender sender) =>
        {
            var command = new AddDepartmentCommand(
                new OrganisationId(id),
                new UserId(request.ManagerId),
                request.Logo,
                request.Name,
                request.Description);

            await sender.Send(command);

            return Results.Ok();
        });
    }
}
