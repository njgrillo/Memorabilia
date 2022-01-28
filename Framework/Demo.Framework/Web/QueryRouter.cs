using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Framework.Web
{
    public class QueryRouter
    {
        private readonly IMediator _mediator;

        public QueryRouter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request, new CancellationToken()).ConfigureAwait(false);
        }
    }
}
