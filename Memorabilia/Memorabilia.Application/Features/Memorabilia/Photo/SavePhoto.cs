namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class SavePhoto
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

            memorabilia.SetPhoto(command.BrandId,
                                 command.Framed,
                                 command.Matted,
                                 command.OrientationId,
                                 command.PersonIds,
                                 command.PhotoTypeId,
                                 command.SizeId,
                                 command.SportIds,
                                 command.TeamIds);

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePhotoViewModel _viewModel;

        public Command(SavePhotoViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public int BrandId => _viewModel.BrandId;

        public bool Framed => _viewModel.Framed;

        public bool Matted => _viewModel.Matted;

        public int MemorabiliaId => _viewModel.MemorabiliaId;

        public int OrientationId => _viewModel.OrientationId;

        public int[] PersonIds => _viewModel.People.Where(person => !person.IsDeleted).Select(person => person.Id).ToArray();

        public int? PhotoTypeId => _viewModel.PhotoTypeId > 0 ? _viewModel.PhotoTypeId : null;

        public int SizeId => _viewModel.SizeId;

        public int[] SportIds => _viewModel.SportIds.ToArray();

        public int[] TeamIds => _viewModel.Teams.Where(team => !team.IsDeleted).Select(team => team.Id).ToArray();
    }
}
