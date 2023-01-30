namespace Memorabilia.Application.Features.Memorabilia.Hat;

public class SaveHat
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

            memorabilia.SetHat(command.BrandId,
                               command.GameDate,
                               command.GameStyleTypeId,
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
        private readonly SaveHatViewModel _viewModel;

        public Command(SaveHatViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GameStyleTypeId 
            => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People
                                            .Where(person => !person.IsDeleted)
                                            .Select(person => person.Id)
                                            .ToArray();

        public int SizeId => _viewModel.SizeId;

        public int? SportId 
            => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int[] TeamIds => _viewModel.Teams
                                          .Where(team => !team.IsDeleted)
                                          .Select(team => team.Id)
                                          .ToArray();
    }
}
