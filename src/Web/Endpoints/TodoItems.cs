using CleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CleanArchitecture.Application.TodoItems.Queries;
using MediatR;

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

    private async Task<IResult> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        var result = await sender.Send(command);
        return Results.Ok(result);
    }

    private async Task<IResult> UpdateTodoItem(Guid id, UpdateTodoItemCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        await Sender.Publish(command);
        return Results.Ok();
    }

    private async Task<IResult> UpdateTodoItemDetail(Guid id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        await Sender.Publish(command);
        return Results.NoContent();
    }

    private async Task<IResult> DeleteTodoItem(ISender sender, Guid id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
