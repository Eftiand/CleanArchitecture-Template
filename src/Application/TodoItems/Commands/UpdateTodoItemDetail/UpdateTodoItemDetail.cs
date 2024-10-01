using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MassTransit;

namespace CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : BaseCommand<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler(
    IApplicationDbContext dbContext)
    : BaseConsumer<UpdateTodoItemDetailCommand>
{
    public override async Task Consume(ConsumeContext<UpdateTodoItemDetailCommand> context)
    {
        var entity = await dbContext.TodoItems
            .FindAsync(Message.Id);

        Guard.Against.NotFound(Message.Id, entity);

        entity.ListId = Message.ListId;
        entity.Priority = PriorityLevel.Medium;
        entity.Note = Message.Note;
    }
}
