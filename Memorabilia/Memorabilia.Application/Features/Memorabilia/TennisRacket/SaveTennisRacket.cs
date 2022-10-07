namespace Memorabilia.Application.Features.Memorabilia.TennisRacket;

public class SaveTennisRacket
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

            memorabilia.SetTennisRacket(command.BrandId,
                                        command.GameDate,
                                        command.GameStyleTypeId,
                                        command.LevelTypeId,
                                        command.PersonId,
                                        command.SizeId,
                                        command.SportId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveTennisRacketViewModel _viewModel;

        public Command(SaveTennisRacketViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person?.Id : null;

        public int SizeId => _viewModel.SizeId;

        public int SportId => Domain.Constants.Sport.Tennis.Id;
    }
}
