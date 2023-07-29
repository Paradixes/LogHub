using Carter;
using LogHub.Application.Organisations.Create;
using LogHub.Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogHub.Web.API.Endpoints;

public class Organisations : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/organisations/create", async (
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
    }
}
