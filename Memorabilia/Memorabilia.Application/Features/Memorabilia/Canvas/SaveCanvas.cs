namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class SaveCanvas
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

            memorabilia.SetCanvas(command.BrandId,
                                  command.Framed,
                                  command.Matted,
                                  command.OrientationId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.Stretched,
                                  command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveCanvasViewModel _viewModel;

        public Command(SaveCanvasViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public bool Framed => _viewModel.Framed;

        public bool Matted => _viewModel.Matted;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int OrientationId => _viewModel.OrientationId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;

        public int[] SportIds => _viewModel.SportIds.ToArray();

        public bool Stretched => _viewModel.Stretched;

        public int[] TeamIds => _viewModel.Teams.Where(person => !person.IsDeleted).Select(team => team.Id).ToArray();
    }
}
