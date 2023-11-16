namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class SaveIndexCard
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetIndexCard(command.SizeId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(IndexCardEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int SizeId 
            => editModel.SizeId;
    }
}
