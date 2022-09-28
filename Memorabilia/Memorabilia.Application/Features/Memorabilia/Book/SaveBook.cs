namespace Memorabilia.Application.Features.Memorabilia.Book
{
    public class SaveBook
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetBook(command.Edition,
                                    command.HardCover,
                                    command.PersonIds,
                                    command.Publisher,
                                    command.SportIds,
                                    command.TeamIds,
                                    command.Title);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveBookViewModel _viewModel;

            public Command(SaveBookViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public string Edition => _viewModel.Edition;

            public bool HardCover => _viewModel.HardCover;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

            public string Publisher => _viewModel.Publisher;

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();

            public string Title => _viewModel.Title;
        }
    }
}
