namespace Memorabilia.Application.Features.ForTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public class SaveForTradeMemorabilia
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.MemorabiliaIds.IsNullOrEmpty())
                return;                      

            if (command.AddedMemorabiliaIds.HasAny())
            {
                Entity.Memorabilia[] itemsToAdd = await memorabiliaRepository.GetAll(command.AddedMemorabiliaIds);

                foreach (Entity.Memorabilia item in itemsToAdd)
                {
                    item.SetForTrade(forTrade: true);

                    await memorabiliaRepository.Update(item);
                }
            }

            if (command.RemovedMemorabiliaIds.HasAny())
            {
                Entity.Memorabilia[] itemsToRemove = await memorabiliaRepository.GetAll(command.RemovedMemorabiliaIds);

                foreach (Entity.Memorabilia item in itemsToRemove)
                {
                    item.SetForTrade(forTrade: false);

                    await memorabiliaRepository.Update(item);
                }
            }
        }
    }

    public class Command(int[] addedMemorabiliaIds = null,
                         int[] removedMemorabiliaIds = null) 
        : DomainCommand, ICommand
    {
        public int[] AddedMemorabiliaIds { get; set; }
            = addedMemorabiliaIds ?? [];

        public int[] MemorabiliaIds
            => AddedMemorabiliaIds.Union(RemovedMemorabiliaIds)
                                  .ToArray();

        public int[] RemovedMemorabiliaIds { get; set; }
            = removedMemorabiliaIds ?? [];
    }
}
