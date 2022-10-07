namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class SaveDrum
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

            memorabilia.SetDrum(command.BrandId, command.PersonIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveDrumViewModel _viewModel;

        public Command(SaveDrumViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();
    }
}
