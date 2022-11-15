namespace Memorabilia.Application.Features.Memorabilia.Shoe;

public class SaveShoe
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

            memorabilia.SetShoe(command.BrandId,
                                command.GameDate,
                                command.GameStyleTypeId,
                                command.LevelTypeId,
                                command.PersonId,
                                command.SizeId,
                                command.SportId,
                                command.TeamId);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveShoeViewModel _viewModel;

        public Command(SaveShoeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public DateTime? GameDate => _viewModel.GameDate;

        public int? GameStyleTypeId => _viewModel.GameStyleTypeId > 0 ? _viewModel.GameStyleTypeId : 0;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int? PersonId => _viewModel.Person?.Id > 0 ? _viewModel.Person.Id : null;

        public int SizeId => _viewModel.SizeId;

        public int? SportId => _viewModel.SportId > 0 ? _viewModel.SportId : null;

        public int? TeamId => _viewModel.Team?.Id > 0 ? _viewModel.Team.Id : null;
    }
}
