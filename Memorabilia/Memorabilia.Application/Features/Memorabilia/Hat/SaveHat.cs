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
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

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
        private readonly HatEditModel _editModel;

        public Command(HatEditModel editModel)
        {
            _editModel = editModel;
        }

        public int BrandId 
            => _editModel.BrandId;

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int[] PersonIds 
            => _editModel.People.ActiveIds();

        public int SizeId 
            => _editModel.SizeId;

        public int? SportId 
            => _editModel.SportId.ToNullableInt();

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();
    }
}
