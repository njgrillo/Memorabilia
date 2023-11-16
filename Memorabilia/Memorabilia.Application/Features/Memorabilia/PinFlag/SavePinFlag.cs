namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class SavePinFlag
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPinFlag(command.GameDate, 
                                   command.GameStyleTypeId, 
                                   command.PersonId, 
                                   command.SportId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(PinFlagEditModel editModel) 
        : DomainCommand, ICommand
    {
        public DateTime? GameDate 
            => editModel.GameDate;

        public int? GameStyleTypeId 
            => editModel.GameStyleTypeId.ToNullableInt();

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int SportId 
            => Constant.Sport.Golf.Id;
    }
}
