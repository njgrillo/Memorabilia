namespace Memorabilia.Application.Features.Collection;

public record GetCollectionMemorabiliaGalleryItems(int CollectionId, 
                                                   PageInfo PageInfo, 
                                                   MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaGalleryItemsModel>
{
    public class Handler : QueryHandler<GetCollectionMemorabiliaGalleryItems, MemorabiliaGalleryItemsModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaGalleryItemsModel> Handle(GetCollectionMemorabiliaGalleryItems query)
        {
            PagedResult<Entity.Memorabilia> result
                = await _memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.Filter);

            return new MemorabiliaGalleryItemsModel(result.Data, result.PageInfo);
        }
    }
}
