using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    : BaseConsumer<TodoItemCreatedEvent>
{
    public override Task Consume(ConsumeContext<TodoItemCreatedEvent> context)
    {
        logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", Message.GetType().Name);

        return Task.CompletedTask;
    }
}
