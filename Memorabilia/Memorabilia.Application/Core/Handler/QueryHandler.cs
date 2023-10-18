namespace Memorabilia.Application.Core.Handler;

public abstract class QueryHandler<TRequest, TResponse> 
    : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
{
    protected abstract Task<TResponse> Handle(TRequest request);

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        => await Handle(request).ConfigureAwait(false);
}
