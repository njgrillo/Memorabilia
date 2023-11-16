namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public class SaveTicket
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetTicket(command.GameDate,
                                  command.GameStyleTypeId,
                                  command.LevelTypeId,
                                  command.PersonId,
                                  command.SizeId,
                                  command.SportId,
                                  command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(TicketEditModel editModel) 
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

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int? SportId 
            => editModel.SportId.ToNullableInt();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
