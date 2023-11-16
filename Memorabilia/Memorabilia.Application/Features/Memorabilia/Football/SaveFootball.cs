namespace Memorabilia.Application.Features.Memorabilia.Football;

public class SaveFootball
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetFootball(command.BrandId,
                                    command.CommissionerId,
                                    command.FootballTypeId,
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

    public class Command(FootballEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public int CommissionerId 
            => editModel.CommissionerId;

        public int? FootballTypeId 
            => editModel.FootballTypeId.ToNullableInt();

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
            => Constant.Sport.Football.Id;

        public int? TeamId
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
