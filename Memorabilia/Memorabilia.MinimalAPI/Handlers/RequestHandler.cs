namespace Memorabilia.MinimalAPI.Handlers;

public abstract class RequestHandler<T>
{
    protected IMediator Mediator { get; }

    public RequestHandler(IMediator mediator)
    {
        Mediator = mediator;
    }

    public abstract Task<IResult> Handle(T request, CancellationToken cancellationToken);
}
