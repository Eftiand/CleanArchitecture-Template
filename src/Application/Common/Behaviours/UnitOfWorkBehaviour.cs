using System.Transactions;
using MassTransit;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Messaging;
using MediatR;

namespace CleanArchitecture.Application.Common.Behaviours;

public class UnitOfWorkBehaviour<TRequest, TResponse>(
    IApplicationDbContext applicationDbContext)
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Only wrap the transaction for valid IRequest types
        if (request is not ICommand)
        {
            var responseNonCommand = await next.Invoke();
            return responseNonCommand;
        }

        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        var response = await next.Invoke();

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        transactionScope.Complete();
        return response;
    }
}
