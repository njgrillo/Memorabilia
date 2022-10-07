namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class SaveFigure
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

            memorabilia.SetFigure(command.BrandId,
                                  command.FigureSpecialtyTypeId,
                                  command.FigureTypeId,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.TeamIds,
                                  command.Year);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveFigureViewModel _viewModel;

        public Command(SaveFigureViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public int? FigureSpecialtyTypeId => _viewModel.FigureSpecialtyTypeId > 0 ? _viewModel.FigureSpecialtyTypeId : 0;

        public int? FigureTypeId => _viewModel.FigureTypeId > 0 ? _viewModel.FigureTypeId : null;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;

        public int[] SportIds => _viewModel.SportIds.ToArray();

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();

        public int? Year => _viewModel.Year;
    }
}
