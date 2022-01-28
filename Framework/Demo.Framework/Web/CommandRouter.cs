using Framework.Handler;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Framework.Web
{
    public class CommandRouter
    {
        private readonly IMediator _mediator;

        public CommandRouter(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(ICommand command)
        {
            await _mediator.Send(command, new CancellationToken()).ConfigureAwait(false);
        }
    }
}
