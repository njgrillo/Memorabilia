namespace Memorabilia.Application.Features.Collection;

public record RemoveCollectionMemorabilia(int CollectionId, 
                                          params int[] DeletedMemorabiliaIds)
    : ICommand
{
    public class Handler : CommandHandler<RemoveCollectionMemorabilia>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task Handle(RemoveCollectionMemorabilia command)
        {
            Entity.Collection collection = await _collectionRepository.Get(command.CollectionId);

            collection.RemoveMemorabilia(command.DeletedMemorabiliaIds);

            await _collectionRepository.Update(collection);
        }
    }
}
