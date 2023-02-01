namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class SaveJerseyNumber
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

            memorabilia.SetJerseyNumber(command.Number,
                                        command.PersonId, 
                                        command.SportId, 
                                        command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveJerseyNumberViewModel _viewModel;

        public Command(SaveJerseyNumberViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? Number => _viewModel.Number;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person.Id : null;

        public int? SportId => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team.Id : null;
    }
}
