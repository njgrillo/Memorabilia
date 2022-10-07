namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class SaveGuitar
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

            memorabilia.SetGuitar(command.BrandId,
                                  command.PersonIds,
                                  command.SizeId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveGuitarViewModel _viewModel;

        public Command(SaveGuitarViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;
    }
}
