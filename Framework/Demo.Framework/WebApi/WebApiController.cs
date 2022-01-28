using Demo.Framework.Handler;
using Framework.Handler;
using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.WebApi
{
    public abstract class WebApiController
    {
        private readonly IMediator _mediator;

        protected WebApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        protected async Task SendCommand(ICommand command)
        {
            await _mediator.Send(command).ConfigureAwait(false);
        }

        protected async Task<TResponse> SendQuery<TResponse>(IQuery<TResponse> query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);

            return response;
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        protected Task SendRequest(IRequest request)
        {
            return _mediator.Send(request, new CancellationToken());
        }

        [DebuggerStepThrough]
        [DebuggerHidden]
        protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request)
        {
            return _mediator.Send(request, new CancellationToken());
        }
    }
}
