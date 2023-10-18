namespace Memorabilia.Application.Core.Handler;

public abstract class CommandHandler<TCommand> 
    : AsyncRequestHandler<TCommand> where TCommand : ICommand
{
    protected abstract Task Handle(TCommand command);

    protected override sealed async Task Handle(TCommand command, CancellationToken cancellation)
    {
        await Handle(command);
    }
}
