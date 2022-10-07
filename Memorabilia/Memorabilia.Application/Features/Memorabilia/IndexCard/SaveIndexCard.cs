namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class SaveIndexCard
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task Handle(Command command)
        {
            var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetIndexCard(command.SizeId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveIndexCardViewModel _viewModel;

        public Command(SaveIndexCardViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int SizeId => _viewModel.SizeId;
    }
}
