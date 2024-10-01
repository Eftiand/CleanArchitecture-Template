using MassTransit;

namespace CleanArchitecture.Domain.Common;

public abstract class BaseConsumer<TConsumer>
    : IConsumer<TConsumer> where TConsumer : class
{
    protected TConsumer Message { get; set; } = default!;
    public abstract Task Consume(ConsumeContext<TConsumer> context);
}
