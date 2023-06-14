namespace Memorabilia.MinimalAPI.Handlers;

public abstract class CommandHandler<T>
{
    protected CommandRouter CommandRouter { get; }

    public CommandHandler(CommandRouter commandRouter)
    {
        CommandRouter = commandRouter;
    }

    public abstract Task Handle(T command, CancellationToken cancellationToken);
}
