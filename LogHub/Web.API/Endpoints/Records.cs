using Application.Records.Records.AddPermission;
using Application.Records.Records.DeletePermission;
using Application.Records.Records.GetPermissions;
using Application.Records.Records.UpdatePermission;
using Carter;
using Domain.Entities.Records;
using Domain.Entities.Users;
using Domain.Exceptions.Records;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Enums;

namespace Web.API.Endpoints;

public class Records : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/records/{recordId:guid}/users/{userId:guid}", async (
            Guid recordId,
            Guid userId,
            [FromBody] PermissionLevel level,
            ISender sender) =>
        {
            try
            {
                var command = new UpdateRecordPermissionCommand(
                    new RecordId(recordId),
                    new UserId(userId),
                    level);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (RecordNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapGet("/api/records/{id:guid}/users", async (
            Guid id,
            ISender sender) =>
        {
            try
            {
                var query = new GetRecordPermissionsByRecordIdQuery(new RecordId(id));

                return Results.Ok(await sender.Send(query));
            }
            catch (RecordNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapPost("/api/records/{recordId:guid}/users/{userId:guid}", async (
            Guid recordId,
            Guid userId,
            [FromBody] PermissionLevel level,
            ISender sender) =>
        {
            try
            {
                var command = new AddRecordPermissionCommand(
                    new RecordId(recordId),
                    new UserId(userId),
                    level);

                await sender.Send(command);

                return Results.Ok();
            }
            catch (RecordNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });

        app.MapDelete("/api/records/{id:guid}/users/{userId:guid}", async (
            Guid id,
            Guid userId,
            ISender sender) =>
        {
            try
            {
                var command = new DeleteRecordPermissionCommand(
                    new RecordId(id),
                    new UserId(userId));

                await sender.Send(command);

                return Results.Ok();
            }
            catch (RecordNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}
