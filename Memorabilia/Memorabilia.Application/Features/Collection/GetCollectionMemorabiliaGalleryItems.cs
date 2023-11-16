namespace Memorabilia.Application.Features.Collection;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollectionMemorabiliaGalleryItems(int CollectionId, 
                                                   PageInfo PageInfo, 
                                                   MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetCollectionMemorabiliaGalleryItems, MemorabiliaGalleryItemsModel>
    {
        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetCollectionMemorabiliaGalleryItems query)
        {
            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
