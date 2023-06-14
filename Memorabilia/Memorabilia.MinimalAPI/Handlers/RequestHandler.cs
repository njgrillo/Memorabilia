namespace Memorabilia.MinimalAPI.Handlers;

public abstract class RequestHandler<T>
{
    protected QueryRouter QueryRouter { get; }

    public RequestHandler(QueryRouter queryRouter)
    {
        QueryRouter = queryRouter;
    }

    public abstract Task<IResult> Handle(T request, CancellationToken cancellationToken);
}
