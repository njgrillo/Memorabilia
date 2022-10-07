namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class SaveCerealBox
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

            memorabilia.SetCerealBox(command.BrandId,
                                     command.LevelTypeId,
                                     command.PersonIds,
                                     command.SportIds,
                                     command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveCerealBoxViewModel _viewModel;

        public Command(SaveCerealBoxViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public int LevelTypeId => _viewModel.LevelTypeId;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int[] SportIds => _viewModel.SportIds.ToArray();

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();
    }
}
