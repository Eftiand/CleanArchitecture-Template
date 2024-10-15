using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using Mapster;
using MassTransit;
using static CleanArchitecture.Domain.Exceptions.CommonExceptions;

namespace CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : BaseCommand<TodoItem>
{
    public Guid Id { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler(
    IApplicationDbContext dbContext)
    : BaseHandler<UpdateTodoItemDetailCommand, TodoItem>
{
    public override async Task<TodoItem> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await dbContext.TodoItems
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity is null)
        {
            throw DomainExceptions.NotFound<TodoItem>();
        }

        entity.Adapt(request);

        return entity;
    }
}
