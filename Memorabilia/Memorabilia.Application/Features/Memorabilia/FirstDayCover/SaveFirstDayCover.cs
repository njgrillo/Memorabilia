namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class SaveFirstDayCover
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetFirstDayCover(command.PersonIds,
                                         command.SizeId,
                                         command.Date,
                                         command.SportIds,
                                         command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(FirstDayCoverEditModel editModel) 
        : DomainCommand, ICommand
    {
        public DateTime? Date 
            => editModel.Date;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int[] SportIds 
            => editModel.SportIds.ToArray();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
