namespace Memorabilia.Application.Features.Memorabilia.Document;

public class SaveDocument
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

            memorabilia.SetDocument(command.PersonIds,
                                    command.SizeId,
                                    command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveDocumentViewModel _viewModel;

        public Command(SaveDocumentViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;

        public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();
    }
}
