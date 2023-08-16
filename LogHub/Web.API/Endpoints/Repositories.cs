using Application.Records.Repositories.AddLabel;
using Application.Records.Repositories.Create;
using Application.Records.Repositories.DeleteLabel;
using Application.Records.Repositories.GetById;
using Application.Records.Repositories.GetLabels;
using Application.Records.Repositories.UpdateLabel;
using Carter;
using Domain.Entities.Organisations;
using Domain.Entities.Records.Labels;
using Domain.Entities.Records.Repositories;
using Domain.Entities.Users;
using Domain.Exceptions;
using Domain.Exceptions.Records;
using Domain.Exceptions.Users;
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

        app.MapGet("/api/repositories/{id:guid}", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetRepositoryByIdQuery(new RepositoryId(id));

                return Results.Ok(await sender.Send(query));
            }
            catch (RepositoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (UserNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPost("/api/repositories/{id:guid}/labels", async (
            Guid id,
            [FromBody] AddLabelRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new AddLabelCommand(
                    new RepositoryId(id),
                    request.Color,
                    request.Name);

                return Results.Ok(await sender.Send(command));
            }
            catch (RepositoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("/api/repositories/{id:guid}/labels", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetLabelsQuery(new RepositoryId(id));

                return Results.Ok(await sender.Send(query));
            }
            catch (RepositoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("/api/repositories/{repoId:guid}/labels/{labelId:guid}", async (
            Guid repoId,
            Guid labelId,
            ISender sender) =>
        {
            try
            {
                var command = new DeleteLabelCommand(
                    new RepositoryId(repoId),
                    new LabelId(labelId));

                await sender.Send(command);

                return Results.Ok();
            }
            catch (RepositoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPut("/api/repositories/{repoId:guid}/labels/{labelId:guid}", async (
            Guid repoId,
            Guid labelId,
            [FromBody] UpdateLabelRequest request,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateLabelCommand(
                    new RepositoryId(repoId),
                    new LabelId(labelId),
                    request.Color,
                    request.Name);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (RepositoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (LabelNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
