namespace Memorabilia.Application.Features.Transaction;

public record GetPurchaseMemorabiliaItemsPaged(PageInfo PageInfo,
                                               MemorabiliaSearchCriteria Filter = null)
    : IQuery<PurchaseMemorabiliasModel>
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetPurchaseMemorabiliaItemsPaged, PurchaseMemorabiliasModel>
    {
        protected override async Task<PurchaseMemorabiliasModel> Handle(GetPurchaseMemorabiliaItemsPaged query)
        {
            PagedResult<Entity.Memorabilia> result
                = await memorabiliaRepository.GetAllPurchased(applicationStateService.CurrentUser.Id,
                                                              query.PageInfo,
                                                              query.Filter ?? new MemorabiliaSearchCriteria());

            return new PurchaseMemorabiliasModel(result.Data, result.PageInfo);
        }
    }
}
