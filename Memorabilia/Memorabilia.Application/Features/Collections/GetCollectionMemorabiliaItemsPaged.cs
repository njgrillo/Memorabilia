namespace Memorabilia.Application.Features.Collections;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollectionMemorabiliaItemsPaged(int CollectionId, 
                                                 PageInfo PageInfo, 
                                                 MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<MemorabiliasModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetCollectionMemorabiliaItemsPaged, MemorabiliasModel>
    {
        protected override async Task<MemorabiliasModel> Handle(GetCollectionMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await memorabiliaRepository.GetAllByCollection(query.CollectionId, query.PageInfo, query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
