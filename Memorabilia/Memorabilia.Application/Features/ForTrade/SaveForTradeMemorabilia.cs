namespace Memorabilia.Application.Features.ForTrade;

public class SaveForTradeMemorabilia
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
            if (!command.MemorabiliaIds.Any())
                return;                      

            if (command.AddedMemorabiliaIds.Any())
            {
                Entity.Memorabilia[] itemsToAdd = await _memorabiliaRepository.GetAll(command.AddedMemorabiliaIds);

                foreach (Entity.Memorabilia item in itemsToAdd)
                {
                    item.SetForTrade(forTrade: true);

                    await _memorabiliaRepository.Update(item);
                }
            }

            if (command.RemovedMemorabiliaIds.Any())
            {
                Entity.Memorabilia[] itemsToRemove = await _memorabiliaRepository.GetAll(command.RemovedMemorabiliaIds);

                foreach (Entity.Memorabilia item in itemsToRemove)
                {
                    item.SetForTrade(forTrade: false);

                    await _memorabiliaRepository.Update(item);
                }
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        public Command(int[] addedMemorabiliaIds = null, 
            int[] removedMemorabiliaIs = null)
        {
            AddedMemorabiliaIds = addedMemorabiliaIds ?? Array.Empty<int>();
            RemovedMemorabiliaIds = removedMemorabiliaIs ?? Array.Empty<int>();
        }

        public int[] AddedMemorabiliaIds { get; set; }
            = Array.Empty<int>();

        public int[] MemorabiliaIds
            => AddedMemorabiliaIds.Union(RemovedMemorabiliaIds)
                                  .ToArray();

        public int[] RemovedMemorabiliaIds { get; set; }
            = Array.Empty<int>();
    }
}
