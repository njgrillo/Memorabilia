namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class SaveBammer
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

            memorabilia.SetBammer(command.BammerTypeId,
                                  command.BrandId,
                                  command.InPackage,
                                  command.LevelTypeId,
                                  command.PersonIds,
                                  command.SportId,
                                  command.TeamIds,
                                  command.Year);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveBammerViewModel _viewModel;

        public Command(SaveBammerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int? BammerTypeId => _viewModel.BammerTypeId > 0 ? _viewModel.BammerTypeId : null;

        public int BrandId => _viewModel.BrandId;

        public bool InPackage => _viewModel.InPackage;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int? SportId => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();

        public int? Year => _viewModel.Year;
    }
}
