namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class SaveBaseball
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBaseball(command.Anniversary,                                        
                                    command.BaseballTypeId,
                                    command.BrandId, 
                                    command.CommissionerId, 
                                    command.GameDate,
                                    command.GameStyleTypeId,
                                    command.LeaguePresidentId,
                                    command.LevelTypeId,
                                    command.PersonId,
                                    command.SizeId, 
                                    command.SportId,
                                    command.TeamIds,
                                    command.Year);                                    

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BaseballEditModel editModel) 
        : DomainCommand, ICommand
    {
        public string Anniversary 
            => editModel.BaseballTypeAnniversary;

        public int? BaseballTypeId
            => editModel.BaseballTypeId
                        .ToNullableInt();           

        public int BrandId 
            => editModel.BrandId;

        public int CommissionerId 
            => editModel.CommissionerId;

        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId
                        .ToNullableInt();

        public int? LeaguePresidentId 
            => editModel.LeaguePresidentId
                        .ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId 
            => editModel.Person?
                        .Id
                        .ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int SportId 
            => Constant.Sport.Baseball.Id;

        public int[] TeamIds 
            => editModel.Teams
                        .ActiveIds();

        public int? Year 
            => editModel.BaseballTypeYear;            
    }
}
