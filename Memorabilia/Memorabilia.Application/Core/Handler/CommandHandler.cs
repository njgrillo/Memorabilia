namespace Memorabilia.Application.Core.Handler;

public abstract class CommandHandler<TCommand> 
    : IRequestHandler<TCommand> where TCommand : ICommand
{
    protected abstract Task Handle(TCommand command);

    async Task IRequestHandler<TCommand>.Handle(TCommand request, CancellationToken cancellationToken)
    {
        await Handle(request);
    }
}
