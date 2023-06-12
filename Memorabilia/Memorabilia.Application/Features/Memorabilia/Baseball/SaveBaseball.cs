namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class SaveBaseball
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

            await _memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly BaseballEditModel _editModel;

        public Command(BaseballEditModel editModel)
        {
            _editModel = editModel;
        }

        public string Anniversary 
            => _editModel.BaseballTypeAnniversary;

        public int? BaseballTypeId
            => _editModel.BaseballTypeId.ToNullableInt();           

        public int BrandId 
            => _editModel.BrandId;

        public int CommissionerId 
            => _editModel.CommissionerId;

        public DateTime? GameDate 
            => _editModel.GameDate;

        public int? GameStyleTypeId 
            => _editModel.GameStyleTypeId.ToNullableInt();

        public int? LeaguePresidentId 
            => _editModel.LeaguePresidentId.ToNullableInt();

        public int LevelTypeId 
            => _editModel.LevelTypeId;

        public int MemorabiliaId 
            => _editModel.MemorabiliaId;

        public int? PersonId 
            => _editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => _editModel.SizeId;

        public int SportId 
            => Constant.Sport.Baseball.Id;

        public int[] TeamIds 
            => _editModel.Teams.ActiveIds();

        public int? Year 
            => _editModel.BaseballTypeYear;            
    }
}
