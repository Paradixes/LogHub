using Application.Records.Repositories.Create;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Users;
using Domain.Exceptions.Records;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Repositories : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/repositories", async (
            [FromBody] CreateRepositoryRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new CreateRepositoryCommand(
                    new UserId(request.CreatorId),
                    new OrganisationId(request.OrganisationId),
                    request.Title,
                    request.Description,
                    request.Icon,
                    request.DataManagementPlan);

                return Results.Ok(await sender.Send(command));
            }
            catch (DataManagementPlanTemplateNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (DataManagementPlanEmptyAnswerException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}
