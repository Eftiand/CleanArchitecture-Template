using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CleanArchitecture.Application.TodoItems.Queries;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Shared.Const;

namespace CleanArchitecture.Web.Endpoints;

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapGet(GetTodoItems)
            .MapDelete(DeleteTodoItem, "{id}");
    }

    private static async Task<IResult> GetTodoItems(ISender sender)
    {
        var result = await sender.Send(new GetAllTodoItemsQuery());
        return Results.Ok(result);
    }

    public async Task<IResult> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        var result = await sender.Send(command);
        return Results.Ok(result);
    }

    public async Task<IResult> UpdateTodoItem(int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await Sender.Publish(command);
        return Results.Ok();
    }

    public async Task<IResult> UpdateTodoItemDetail(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await Sender.Publish(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
