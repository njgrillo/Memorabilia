namespace Memorabilia.Application.Features.Collection;

public record GetCollectionMemorabiliaItemsPaged(int CollectionId, 
                                                 PageInfo PageInfo, 
                                                 MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<MemorabiliasModel>
{
    public class Handler : QueryHandler<GetCollectionMemorabiliaItemsPaged, MemorabiliasModel>
    {
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaRepository)
        {
            _memorabiliaRepository = memorabiliaRepository;
        }

        protected override async Task<MemorabiliasModel> Handle(GetCollectionMemorabiliaItemsPaged query)
        {
            var result = await _memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
