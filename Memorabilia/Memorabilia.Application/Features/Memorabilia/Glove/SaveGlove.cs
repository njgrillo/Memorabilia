namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class SaveGlove
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

            memorabilia.SetGlove(command.BrandId,
                                 command.GameDate,
                                 command.GamePersonId,
                                 command.GameStyleTypeId,
                                 command.GloveTypeId,
                                 command.LevelTypeId,
                                 command.PersonIds,
                                 command.SizeId,
                                 command.SportId,
                                 command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveGloveViewModel _viewModel;

        public Command(SaveGloveViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GamePersonId => _viewModel.GamePersonId > 0 ? _viewModel.GamePersonId : null;

        public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : null;

        public int? GloveTypeId => _viewModel.GloveTypeId > 0 ? _viewModel.GloveTypeId : null;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int SizeId => _viewModel.SizeId;

        public int? SportId => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();
    }
}
