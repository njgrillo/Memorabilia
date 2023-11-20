namespace Memorabilia.Application.Features.Transaction;

public record GetSoldMemorabiliaTransactionPaged(PageInfo PageInfo,
    MemorabiliaSearchCriteria Filter = null)
    : IQuery<MemorabiliaTransactionsModel>
{
    public class Handler(IMemorabiliaTransactionRepository memorabiliaTransactionRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSoldMemorabiliaTransactionPaged, MemorabiliaTransactionsModel>
    {
        protected override async Task<MemorabiliaTransactionsModel> Handle(GetSoldMemorabiliaTransactionPaged query)
        {
            PagedResult<Entity.MemorabiliaTransaction> result
                = await memorabiliaTransactionRepository.GetAllSales(query.PageInfo,
                                                                     applicationStateService.CurrentUser.Id,
                                                                     query.Filter ?? new MemorabiliaSearchCriteria());

            return new MemorabiliaTransactionsModel(result.Data, result.PageInfo);
        }
    }
}
