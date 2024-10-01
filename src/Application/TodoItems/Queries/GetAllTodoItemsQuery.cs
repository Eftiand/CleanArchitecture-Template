using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using MassTransit;

namespace CleanArchitecture.Application.TodoItems.Queries;

public record GetAllTodoItemsQuery : BaseQuery<Result<List<TodoItem>>>;

public class GetAllTodoItemsQueryConsumer(IApplicationDbContext dbContext)
    : BaseHandler<GetAllTodoItemsQuery, Result<List<TodoItem>>>
{
    public override async Task<Result<List<TodoItem>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await dbContext.TodoItems
            .ToListAsync(cancellationToken: cancellationToken);

        return Result<List<TodoItem>>.Success(items);
    }
}
