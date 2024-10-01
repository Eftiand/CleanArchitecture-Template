using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using MassTransit;

namespace CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : BaseCommand<TodoItem>
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTodoItemCommandHandler(
    IApplicationDbContext dbContext)
    : BaseConsumer<UpdateTodoItemCommand>
{
    public override async Task Consume(ConsumeContext<UpdateTodoItemCommand> context)
    {
        var entity = await dbContext.TodoItems
            .FindAsync(this.Message.Id);

        Guard.Against.NotFound(context.Message.Id, entity);

        entity.Title = Message.Title;
        entity.Done = Message.Done;
    }
}
