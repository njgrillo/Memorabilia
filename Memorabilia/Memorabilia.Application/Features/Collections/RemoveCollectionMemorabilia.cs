namespace Memorabilia.Application.Features.Collections;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record RemoveCollectionMemorabilia(int CollectionId, 
                                          params int[] DeletedMemorabiliaIds)
    : ICommand
{
    public class Handler(ICollectionRepository collectionRepository) 
        : CommandHandler<RemoveCollectionMemorabilia>
    {
        protected override async Task Handle(RemoveCollectionMemorabilia command)
        {
            Entity.Collection collection = await collectionRepository.Get(command.CollectionId);

            collection.RemoveMemorabilia(command.DeletedMemorabiliaIds);

            await collectionRepository.Update(collection);
        }
    }
}
