namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class SavePylon
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

            memorabilia.SetPylon(command.GameDate,
                                 command.GameStyleTypeId,
                                 command.LevelTypeId,
                                 command.SizeId,
                                 command.SportId,
                                 command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePylonViewModel _viewModel;

        public Command(SavePylonViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int SizeId => _viewModel.SizeId;

        public int SportId => Constant.Sport.Football.Id;

        public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team?.Id : null;
    }
}
