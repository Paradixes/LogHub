using Application.Organisations.AddDepartment;
using Application.Organisations.Create;
using Application.Organisations.GetById;
using Application.Organisations.GetByManagerId;
using Application.Organisations.GetDepartments;
using Application.Organisations.GetUsers;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
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

        app.MapGet("api/organisations/{id:guid}/departments", async (Guid id, ISender sender) =>
        {
            var query = new GetDepartmentsByOrganisationQuery(id);

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/{id:guid}/users", async (Guid id, ISender sender) =>
        {
            var query = new GetUsersByOrganisationQuery(new OrganisationId(id));

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });

        app.MapGet("api/organisations/manager/{managerId:guid}", async (Guid managerId, ISender sender) =>
        {
            var query = new GetOrganisationByManagerIdQuery(managerId);

            var result = await sender.Send(query);

            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result.Value);
        });
    }
}
