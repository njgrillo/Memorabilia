namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class SavePylon
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPylon(command.GameDate,
                                 command.GameStyleTypeId,
                                 command.LevelTypeId,
                                 command.SizeId,
                                 command.SportId,
                                 command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(PylonEditModel editModel) 
        : DomainCommand, ICommand
    {
        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int SizeId 
            => editModel.SizeId;

        public int SportId 
            => Constant.Sport.Football.Id;

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
