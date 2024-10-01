namespace CleanArchitecture.Web.Infrastructure;

public abstract class EndpointGroupBase
{
    public IPublishEndpoint Sender { get; set; } = default!;

    public abstract void Map(WebApplication app);
}
