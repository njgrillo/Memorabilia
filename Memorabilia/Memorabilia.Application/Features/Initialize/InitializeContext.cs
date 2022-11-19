namespace Memorabilia.Application.Features.Initialize;

public record InitializeContext() : ICommand
{
    public class Handler : CommandHandler<InitializeContext>
    {
        private readonly IContextLoader _contextLoader;

        public Handler(IContextLoader contextLoader)
        {
            _contextLoader = contextLoader;
        }

        protected override async Task Handle(InitializeContext command)
        {
            await _contextLoader.Load();
        }
    }
}
