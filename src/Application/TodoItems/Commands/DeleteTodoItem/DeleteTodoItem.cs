using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MassTransit;

namespace CleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(Guid Id) : BaseCommand<Guid>;

public class DeleteTodoItemCommandHandler(
    IApplicationDbContext dbContext)
    : BaseHandler<DeleteTodoItemCommand, Guid>
{
    public override async Task<Guid> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.TodoItems
            .FindAsync(request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        dbContext.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        return entity.Id;
    }
}
