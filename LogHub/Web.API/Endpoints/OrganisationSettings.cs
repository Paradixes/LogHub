using Application.OrganisationSettings.GetById;
using Application.OrganisationSettings.Update;
using Carter;
using Domain.Entities.Organisations;
using Domain.Exceptions.Organisations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class OrganisationSettings : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/organisations/{id:guid}/settings", async (Guid id, ISender sender) =>
        {
            try
            {
                var query = new GetOrganisationSettingsQuery(new OrganisationId(id));

                return Results.Ok(await sender.Send(query));
            }
            catch (OrganisationNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("api/organisations/{id:guid}/settings", async (
            Guid id,
            [FromBody] UpdateOrganisationSettingRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateOrganisationSettingCommand(
                    new OrganisationId(id),
                    request.Option,
                    request.Role);

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
