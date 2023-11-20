namespace Memorabilia.Application.Features.ForTrade;

[AuthorizeByPermission(Enum.Permission.BuySellTrade)]
public record GetForTradeMemorabiliaItemsPaged(PageInfo PageInfo,
                                               MemorabiliaSearchCriteria MemorabiliaSearchCriteria = null)
    : IQuery<MemorabiliasModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IMemorabiliaItemRepository memorabiliaRepository) 
        : QueryHandler<GetForTradeMemorabiliaItemsPaged, MemorabiliasModel>
    {
        protected override async Task<MemorabiliasModel> Handle(GetForTradeMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result 
                = await memorabiliaRepository.GetAllForTrade(applicationStateService.CurrentUser.Id, 
                                                             query.PageInfo, 
                                                             query.MemorabiliaSearchCriteria);

            return new MemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
