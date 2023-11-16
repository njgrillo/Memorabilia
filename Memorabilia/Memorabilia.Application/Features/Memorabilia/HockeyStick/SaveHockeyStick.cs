namespace Memorabilia.Application.Features.Memorabilia.HockeyStick;

public class SaveHockeyStick
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetHockeyStick(command.BrandId,
                                       command.GameDate,
                                       command.GameStyleTypeId,
                                       command.LevelTypeId,
                                       command.PersonId,
                                       command.SizeId,
                                       command.SportId,
                                       command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(HockeyStickEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int SportId 
            => Constant.Sport.Hockey.Id;

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
