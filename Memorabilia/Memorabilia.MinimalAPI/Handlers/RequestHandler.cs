namespace Memorabilia.MinimalAPI.Handlers;

public abstract class RequestHandler<T>(IMediator mediator)
{
    protected IMediator Mediator { get; } 
        = mediator;

    public abstract Task<IResult> Handle(T request, CancellationToken cancellationToken);
}
