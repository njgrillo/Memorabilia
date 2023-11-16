namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class SaveBasketball
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBasketball(command.BasketballTypeId,
                                      command.BrandId,
                                      command.CommissionerId,
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

    public class Command(BasketballEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int? BasketballTypeId 
            => editModel.BasketballTypeId
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
            => Constant.Sport.Basketball.Id;

        public int? TeamId 
            => editModel.Team?
                        .Id
                        .ToNullableInt() ?? null;
    }
}
