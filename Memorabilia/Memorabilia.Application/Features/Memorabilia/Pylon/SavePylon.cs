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
            Entity.Memorabilia memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId);

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
        private readonly PylonEditModel _editModel;

        public Command(PylonEditModel editModel)
        {
            _editModel = editModel;
        }

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int SizeId 
            => _editModel.SizeId;

        public int SportId 
            => Constant.Sport.Football.Id;

        public int? TeamId 
            => _editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
