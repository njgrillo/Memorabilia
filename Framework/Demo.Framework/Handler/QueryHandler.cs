using MediatR;
using System.Threading.Tasks;

namespace Demo.Framework.Handler
{
    public abstract class QueryHandler<TQuery, TResponse> : AsyncRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        protected abstract Task<TResponse> Handle(TQuery query);

        protected sealed override async Task<TResponse> HandleCore(TQuery request)
        {
            var response = await Handle(request).ConfigureAwait(false);

            return response;
        }
    }
}
