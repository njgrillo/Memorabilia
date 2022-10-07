namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class SavePlayingCard 
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

            memorabilia.SetPlayingCard(command.PersonId,
                                       command.SizeId,
                                       command.SportId,
                                       command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePlayingCardViewModel _viewModel;

        public Command(SavePlayingCardViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;

        public int SizeId => _viewModel.SizeId;

        public int? SportId => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team?.Id : null;
    }
}
