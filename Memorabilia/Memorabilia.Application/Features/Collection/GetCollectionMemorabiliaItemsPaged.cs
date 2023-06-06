namespace Memorabilia.Application.Features.Collection;

public record GetCollectionMemorabiliaItemsPaged(int CollectionId, 
    PageInfo PageInfo, 
    MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<MemorabiliaItemsModel>
{
    public class Handler : QueryHandler<GetCollectionMemorabiliaItemsPaged, MemorabiliaItemsModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliaItemsModel> Handle(GetCollectionMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.MemorabiliaSearchCriteria);

            return new MemorabiliaItemsModel(result.Data, result.PageInfo);
        }
    }
}
