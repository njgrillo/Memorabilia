namespace Memorabilia.Application.Features.Collections;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollectionMemorabiliaGalleryItemsPaged(int CollectionId, 
                                                   PageInfo PageInfo, 
                                                   MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetCollectionMemorabiliaGalleryItemsPaged, MemorabiliaGalleryItemsModel>
    {
        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetCollectionMemorabiliaGalleryItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
