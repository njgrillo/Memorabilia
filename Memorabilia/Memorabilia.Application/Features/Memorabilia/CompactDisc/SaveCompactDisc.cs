namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class SaveCompactDisc
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetCompactDisc(command.PersonIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(CompactDiscEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();
    }
}
